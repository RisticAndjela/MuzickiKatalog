using muzickiKatalog.GUI.MVVM.View.General;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support;
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
using contributor = muzickiKatalog.Layers.Model.contributors;
namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for MakeGroup.xaml
    /// </summary>
    public partial class MakeGroup : UserControl
    {
        private contributor.Editor editor;
        private bool activity = false;
        public MakeGroup(contributor.Editor editor)
        {
            InitializeComponent();
            foreach (var artist in ArtistRepository.getAll().Values)
            {
                this.artists.Items.Add($"{artist.Name} {artist.LastName}");
            }
        }

        private void activeButton(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Name == "active")
                {
                    ((Button)FindName("active")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBBD"));
                    ((Button)FindName("inactive")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6AA68"));
                    activity = true;
                }
                else
                {
                    ((Button)FindName("inactive")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFBBD"));
                    ((Button)FindName("active")).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E6AA68"));
                    activity = false;
                }
            }
        }
        private void doneButton(object sender, RoutedEventArgs e)
        {
            new MessageWindow("SUCCESFUL", "MADE A GROUP").Show();
        }
    }
}
