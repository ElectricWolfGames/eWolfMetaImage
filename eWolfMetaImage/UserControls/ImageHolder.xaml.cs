using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace eWolfMetaImage.UserControls
{
    /// <summary>
    /// Interaction logic for ImageHolder.xaml
    /// </summary>
    public partial class ImageHolder : UserControl
    {
        private string _fileName;

        public ImageHolder(string path)
        {
            InitializeComponent();

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(path, UriKind.Absolute);
            bi.EndInit();

            ShowImage.Source = bi;
        }

        public ImageHolder()
        {
            InitializeComponent();
        }
    }
}
