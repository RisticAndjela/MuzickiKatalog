using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace muzickiKatalog.GUI.MVVM.View.Admin
{
    public partial class ManageAds : Window
    {
        public ManageAds()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();
                SelectedImage.Source = bitmap;
            }
        }

        private void SaveAd_Click(object sender, RoutedEventArgs e)
        {
            string description = ImageDescription.Text;
            MessageBox.Show("Ad saved with description: " + description);
        }
    }
}
