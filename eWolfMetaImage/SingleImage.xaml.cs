using eWolfMetaImage.Data;
using eWolfTagHolders.Services;
using eWolfTagHolders.Tags;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace eWolfMetaImage
{
    public partial class SingleImage : Window
    {
        private string _allTagsSelection = string.Empty;
        private TagListHolders _availableTags = new TagListHolders();
        private List<ImageDetails> _imageHolders = new List<ImageDetails>();
        private int _index = 0;

        public SingleImage()
        {
            InitializeComponent();

            ServiceLocator.Instance.InjectService<LocationTagHolderServices>(LocationTagHolderServices.Load());
            ServiceLocator.Instance.InjectService<GroupTagsHolderService>(new GroupTagsHolderService());

            PopulateGroupData();
            PopulateTagData();

            DateTime dt = DateTime.Now;
            Date.Text = dt.ToString("yyyy-MM-dd");

            NamingSets.Items.Add("Default");
            NamingSets.Items.Add("Home");
            NamingSets.Items.Add("GCR");
            NamingSets.Items.Add("ModelsLayouts");
            NamingSets.Items.Add("Cattington");

            ApplyLocationTagsToList();
        }

        private void AllTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            _allTagsSelection = (string)comboBox.SelectedItem;
        }

        private void ApplyAllTagsToList()
        {
            TagList.Items.Clear();
            foreach (string tagName in _availableTags.Tags)
            {
                TagList.Items.Add(tagName);
            }
        }

        private void ApplyLocationTagsToList()
        {
            AllTag.Items.Clear();
            var allTagHolder = LocationTagHolderServices.GetLocationTagHolderServices;
            foreach (var atag in allTagHolder.Tags)
            {
                AllTag.Items.Add(atag);
            }
        }

        private void Button_AddLocationTagClick(object sender, RoutedEventArgs e)
        {
            string newTag = NewLocationTagsToAdd.Text;

            LocationTagHolderServices lths = LocationTagHolderServices.GetLocationTagHolderServices;

            lths.Add(newTag);
            lths.TidyUp();
            ApplyLocationTagsToList();
            lths.Save();
        }

        private void Button_AddTagClick(object sender, RoutedEventArgs e)
        {
            string newTag = NewTagsToAdd.Text;

            _availableTags.Add(newTag);
            _availableTags.TidyUp();
            ApplyAllTagsToList();
            _availableTags.Save();
        }

        private void Button_ClearTags(object sender, RoutedEventArgs e)
        {
            if (!IsValid(_index))
                return;

            ImageDetails item = _imageHolders[_index];
            if (item == null)
                return;

            item.TagHolder.ClearAllTagsAfterFirst();
            ShowImage();
        }

        private void Button_CopyTags(object sender, RoutedEventArgs e)
        {
            if (_index == 0)
                return;

            ImageDetails item = _imageHolders[_index];
            if (item == null)
                return;

            ImageDetails itemPrev = _imageHolders[_index - 1];

            item.TagHolder.ClearAllTagsAfterFirst();
            item.TagHolder.CopyTags(itemPrev.TagHolder);
            ShowImage();
        }

        private void Button_GetImages(object sender, RoutedEventArgs e)
        {
            _imageHolders = new List<ImageDetails>();

            string[] files = GetAllImages();

            foreach (string file in files)
            {
                ImageDetails imageDetails = new ImageDetails(file);
                _imageHolders.Add(imageDetails);
            }

            ClearAllSetting();
            ShowImage();
        }

        private void Button_NextClick(object sender, RoutedEventArgs e)
        {
            SaveCurrentImage();

            if (_index < _imageHolders.Count - 1)
                _index++;

            ShowImage();
        }

        private void Button_PrevClick(object sender, RoutedEventArgs e)
        {
            SaveCurrentImage();
            if (_index > 0)
                _index--;

            ShowImage();
        }

        private void Button_UpdateAllTags(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _imageHolders.Count; i++)
            {
                CheckImageTag(_imageHolders[i]);
                SaveCurrentImage(_imageHolders[i]);
            }
        }

        private void Button_UpdateDateTags(object sender, RoutedEventArgs e)
        {
            string dt = Date.Text;

            for (int i = 0; i < _imageHolders.Count; i++)
            {
                _imageHolders[i].TagHolder.AddTag(dt);
                CheckImageTag(_imageHolders[i]);

                SaveCurrentImage(_imageHolders[i]);
            }
        }

        private void CheckImageTag(ImageDetails imageDetails)
        {
            GroupTagsHolderService groupHolder = GroupTagsHolderService.GetGroupTagsHolder;
            TagHolders tagHolder = imageDetails.TagHolder;
            groupHolder.AdjustTags(tagHolder);

            tagHolder.AddTag(_allTagsSelection);
        }

        private void ClearAllSetting()
        {
            _index = 0;
            _allTagsSelection = string.Empty;
        }

        private string[] GetAllImages()
        {
            string[] files = Directory.GetFiles(ImageFolder.Text, "*.jpg", SearchOption.AllDirectories);
            return files;
        }

        private bool IsValid(int index)
        {
            if (_imageHolders.Count < index)
                return false;

            if (index < 0)
                return false;

            return true;
        }

        private void NamingSets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _availableTags.Set = NamingSets.SelectedValue.ToString();
            ApplyAllTagsToList();
        }

        private void PopulateGroupData()
        {
            GroupTagsHolderService groupHolder = GroupTagsHolderService.GetGroupTagsHolder;
            groupHolder.AddDefaultGroups();
        }

        private void PopulateTagData()
        {
            _availableTags = TagListHolders.Load();

            _availableTags.Set = "Default";
            /*var groupHolder = GroupTagsHolderService.GetGroupTagsHolder;
            foreach (var group in groupHolder.GroupTagCollection)
            {
                _availableTags.Add(group.MasterTag);
            }

            ApplyLocationTagsToList();

            var allTagHolder = LocationTagHolderServices.GetLocationTagHolderServices;
            foreach (var atag in allTagHolder.Tags)
            {
                _availableTags.Add(atag);
            }*/

            _availableTags.TidyUp();
            ApplyAllTagsToList();
            _availableTags.Save();
        }

        private void SaveCurrentImage()
        {
            if (!IsValid(_index))
                return;

            Image.Source = null;

            SaveCurrentImage(_imageHolders[_index]);
        }

        private void SaveCurrentImage(ImageDetails item)
        {
            try
            {
                if (item == null)
                    return;

                if (!item.Modifiy)
                    return;

                string newPath = item.NewPath;
                string oldPath = item.FilePath;
                File.Move(oldPath, newPath);
            }
            catch { }
            item.Update();
        }

        private void ShowImage()
        {
            if (!IsValid(_index))
                return;

            CheckImageTag(_imageHolders[_index]);

            string filename = _imageHolders[_index].FilePath;
            NewFileName.Content = _imageHolders[_index].DisplayTags;

            MemoryStream ms = new MemoryStream();
            BitmapImage bi = new BitmapImage();
            byte[] bytArray = File.ReadAllBytes(filename);
            ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            Image.Source = bi;
        }

        private void TagList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!IsValid(_index))
                return;

            ListBox listBox = sender as ListBox;

            ImageDetails item = _imageHolders[_index];
            item.AddRemoveTag((string)listBox.SelectedItem);

            ShowImage();
        }
    }
}