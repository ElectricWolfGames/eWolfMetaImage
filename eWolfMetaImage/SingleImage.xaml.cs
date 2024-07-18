using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using eWolfMetaImage.Data;
using eWolfTagHolders.Services;
using eWolfTagHolders.Tags;

namespace eWolfMetaImage
{
    // https://github.com/unosquare/ffmediaelement

    public partial class SingleImage : Window, INotifyPropertyChanged
    {
        private string _allTagsSelection = string.Empty;
        private TagListHolders _availableTags = new TagListHolders();
        private List<ImageDetails> _imageHolders = new List<ImageDetails>();
        private int _index = 0;
        private string _videoFileName;

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
            NamingSets.Items.Add("Northampton And Lamport");

            ApplyLocationTagsToList();

            mePlayer.MediaEnded += MePlayer_MediaEnded;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string VideoFileNameToPlay
        {
            get
            {
                return _videoFileName;
            }
            set
            {
                _videoFileName = value;
                OnPropertyChanged("VideoFileNameToPlay");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
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

        private void Button_ApplyToAllClick(object sender, RoutedEventArgs e)
        {
            ImageDetails itemPrev = _imageHolders[0];
            for (int i = 1; i < _imageHolders.Count; i++)
            {
                ImageDetails item = _imageHolders[i];
                if (item == null)
                    continue;

                item.TagHolder.ClearAllTagsAfterFirst();
                item.TagHolder.CopyTags(itemPrev.TagHolder);

                SaveCurrentImage(item);
            }
            ShowImage();
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
                //RemoveText(_imageHolders[i], "London");
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
            string[] files = Directory.EnumerateFiles(ImageFolder.Text, "*.*", SearchOption.AllDirectories)
                    .Where(s =>
                    s.ToUpper().EndsWith(".JPG")
                    || s.ToUpper().EndsWith(".MOV")
                    || s.ToUpper().EndsWith(".MTS")
                    || s.ToUpper().EndsWith(".MP4")
                    ).ToArray();
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

        private void mediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            int i = 0;
            i++;
            string path = mePlayer.Source.AbsolutePath;
            mePlayer.Play();
        }

        private void MePlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            //_videoTaggerViewModel.SetNextVideo(pathField.Text);
            //ShowNextVideoDetails();
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

        private void RemoveText(ImageDetails imageDetails, string textToRemove)
        {
            TagHolders tagHolder = imageDetails.TagHolder;
            tagHolder.RemoveTag(textToRemove);
        }

        private void SaveCurrentImage()
        {
            if (!IsValid(_index))
                return;

            ShowImageUI.Source = null;
            if (_imageHolders.Count == 0)
                return;

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

            if (filename.EndsWith(".MOV"))
            {
                var uri = new Uri(filename);
                if (mePlayer.Source?.LocalPath != uri.LocalPath)
                {
                    ShowImageUI.Source = null;
                    mePlayer.Source = uri;
                    mePlayer.Play();
                    mePlayer.IsEnabled = true;
                }
                return;
            }
            else if (filename.EndsWith(".MTS") || filename.EndsWith(".MP4"))
            {
                var uri = new Uri(filename, UriKind.RelativeOrAbsolute);
                if (mePlayer.Source?.LocalPath != uri.LocalPath)
                {
                    mePlayer.Stop();
                    mePlayer.IsEnabled = false;
                    ShowImageUI.Source = null;

                    mePlayer.Source = uri;
                    mePlayer.IsEnabled = true;
                    mePlayer.ScrubbingEnabled = false;
                    mePlayer.IsMuted = true;

                    mePlayer.Play();
                }

                return;
            }
            else
            {
                mePlayer.Stop();
                mePlayer.IsEnabled = false;
            }

            MemoryStream ms = new MemoryStream();
            BitmapImage bi = new BitmapImage();
            byte[] bytArray = File.ReadAllBytes(filename);
            ms.Write(bytArray, 0, bytArray.Length); ms.Position = 0;
            bi.BeginInit();
            bi.StreamSource = ms;
            bi.EndInit();
            ShowImageUI.Source = bi;
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