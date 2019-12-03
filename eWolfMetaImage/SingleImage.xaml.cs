using eWolfMetaImage.Data;
using eWolfTagHolders.Services;
using eWolfTagHolders.Tags;
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
        private List<ImageDetails> _imageHolders = new List<ImageDetails>();
        private int _index = 0;

        public SingleImage()
        {
            InitializeComponent();

            ServiceLocator.Instance.InjectService<AllTagHolder>(new AllTagHolder());

            PopulateGroupData();
            PopulateTagData();
        }

        private void AllTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            _allTagsSelection = (string)comboBox.SelectedItem;
        }

        private void Button_ClearTags(object sender, RoutedEventArgs e)
        {
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

            _index = 0;
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

        private void CheckImageTag(ImageDetails imageDetails)
        {
            GroupTagsHolder groupHolder = GroupTagsHolder.GetGroupTagsHolder;
            TagHolders tagHolder = imageDetails.TagHolder;
            groupHolder.AdjustTags(tagHolder);

            tagHolder.AddTag(_allTagsSelection);
        }

        private string[] GetAllImages()
        {
            string[] files = Directory.GetFiles(ImageFolder.Text, "*.jpg", SearchOption.AllDirectories);
            return files;
        }

        private void PopulateGroupData()
        {
            var groupHolder = GroupTagsHolder.GetGroupTagsHolder;

            GroupTags groupTags = new GroupTags("92214,LeicesterCity,Class9F,2-10-0");
            groupTags.Add("92214");
            groupTags.AddClearTags("LeicesterCity");
            groupTags.AddClearTags("Class9F");
            groupHolder.GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("6990,WitherslackHall,4-6-0");
            groupTags.Add("6990");
            groupTags.AddClearTags("WitherslackHall");
            groupHolder.GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("47406,Jinty,Class3F,0-6-0");
            groupTags.Add("47406");
            groupHolder.GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("D123,LeicestershireAndDerbyshireYeomanry");
            groupTags.Add("D123");
            groupTags.AddClearTags("LeicestershireAndDerbyshireYeomanry");
            groupHolder.GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("48305,Stanier,Class8F,2-8-0");
            groupTags.Add("48305");
            groupHolder.GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("926,Repton,4-4-0");
            groupTags.Add("926");
            groupTags.Add("Repton");
            groupHolder.GroupTagCollection.Add(groupTags);

            groupTags = new GroupTags("78018,Standard2MT,2-6-0");
            groupTags.Add("78018");
            groupHolder.GroupTagCollection.Add(groupTags);
        }

        private void PopulateTagData()
        {
            TagList.Items.Add("92214");
            TagList.Items.Add("6990");
            TagList.Items.Add("50017");
            TagList.Items.Add("Class08");
            TagList.Items.Add("DMU");

            TagList.Items.Add("45305");
            TagList.Items.Add("48305");

            var groupHolder = GroupTagsHolder.GetGroupTagsHolder;
            foreach (var group in groupHolder.GroupTagCollection)
            {
                TagList.Items.Add(group.MasterTag);
            }

            var allTagHolder = AllTagHolder.GetAllTagHolder;
            foreach (var atag in allTagHolder.AllTags)
            {
                TagList.Items.Add(atag);
                AllTag.Items.Add(atag);
            }
        }

        private void SaveCurrentImage()
        {
            Image.Source = null;

            SaveCurrentImage(_imageHolders[_index]);
        }

        private void SaveCurrentImage(ImageDetails item)
        {
            if (item == null)
                return;

            if (!item.Modifiy)
                return;

            string newPath = item.NewPath;
            string oldPath = item.FilePath;
            File.Move(oldPath, newPath);

            item.Update();
        }

        private void ShowImage()
        {
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
            ListBox listBox = sender as ListBox;

            ImageDetails item = _imageHolders[_index];
            item.AddRemoveTag((string)listBox.SelectedItem);

            ShowImage();
        }
    }
}