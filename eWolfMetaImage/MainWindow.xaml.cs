using eWolfMetaImage.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace eWolfMetaImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ImageHolder> _items = new List<ImageHolder>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _items = new List<ImageHolder>();
            string[] files = GetAllImages();

            foreach (string file in files)
            {
                Console.WriteLine(file);
                _items.Add(new ImageHolder(file));
            }
            Items.ItemsSource = _items;
        }

        private string[] GetAllImages()
        {
            string[] files = Directory.GetFiles(ImageFolder.Text, "*.*", SearchOption.AllDirectories);

            return files;
        }
    }
}
