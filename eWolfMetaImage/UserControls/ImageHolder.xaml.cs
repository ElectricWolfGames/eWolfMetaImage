using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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