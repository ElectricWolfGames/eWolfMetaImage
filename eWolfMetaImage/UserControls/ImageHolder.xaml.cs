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
        public ImageHolder()
        {
            InitializeComponent();
        }

        internal void SetImage(string fileName)
        {
            // sset the image data
            // load the file

            Uri uri = new Uri(fileName);
            BitmapImage bitmapImage = new BitmapImage(uri);

            ImageData.Source = bitmapImage;
        }
    }
}