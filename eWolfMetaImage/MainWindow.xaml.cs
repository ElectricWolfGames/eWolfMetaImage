using eWolfMetaImage.UserControls;

using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace eWolfMetaImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ImageHolder> _imageHolders = new List<ImageHolder>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _imageHolders = new List<ImageHolder>();

            string[] files = GetAllImages();

            foreach (string file in files)
            {
                ImageHolder ih = new ImageHolder();
                ih.SetImage(file);
                _imageHolders.Add(ih);
            }
            ImageList.ItemsSource = _imageHolders;
        }

        private string[] GetAllImages()
        {
            string[] files = Directory.GetFiles(ImageFolder.Text, "*.*", SearchOption.AllDirectories);

            return files;
        }
    }
}