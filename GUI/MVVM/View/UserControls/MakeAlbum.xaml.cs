using contributor=muzickiKatalog.Layers.Model.contributors;
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
using muzickiKatalog.GUI.MVVM.View.General;
using muzickiKatalog.Layers.Repository.performatorium;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for MakeAlbum.xaml
    /// </summary>
    public partial class MakeAlbum : UserControl
    {
        public MakeAlbum(contributor.Editor editor)
        {
            InitializeComponent();
            foreach (var artist in ArtistRepository.getAll().Values)
            {
                this.artists.Items.Add($"{artist.Name} {artist.LastName}");
            }
            foreach (var genre in GenreRepository.getAll().Keys)
            {
                this.genres.Items.Add(genre);
            }
        }
        private void doneButton(object sender, RoutedEventArgs e) { new MessageWindow("SUCCESFUL", "MADE MATERIAL").Show(); }
        private void newGenreButton(object sender, RoutedEventArgs e) { newGenrePanel.Visibility = Visibility.Visible; }
        private void addBtton(object sender, RoutedEventArgs e) { new MessageWindow("SUCCESFUL", "MADE GENRE").Show(); }

    }
}
