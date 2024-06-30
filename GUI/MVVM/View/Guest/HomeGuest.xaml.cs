using muzickiKatalog.GUI.MVVM.ViewModel;
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
using System.Windows.Shapes;

namespace muzickiKatalog.GUI.MVVM.View.Guest
{
    /// <summary>
    /// Interaction logic for HomeGuest.xaml
    /// </summary>
    public partial class HomeGuest : Window
    {
        public HomeGuest()
        {
            InitializeComponent();
            DataContext = new ControlsViewModel();

        }
        private void LogInHandler(object sender, RoutedEventArgs e)
        {

        }
        private void SearcHandler(object sender, RoutedEventArgs e)
        {
            contentPanelSearch.Visibility = Visibility.Visible;
            contentPanelPopular.Visibility = Visibility.Hidden;
        }
        private void PopularHandler(object sender, RoutedEventArgs e)
        {
            contentPanelSearch.Visibility = Visibility.Hidden;
            contentPanelPopular.Visibility = Visibility.Visible;
        }
    }
}
