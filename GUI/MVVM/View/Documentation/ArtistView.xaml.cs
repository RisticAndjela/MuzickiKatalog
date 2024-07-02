using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
using System.Windows;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for Artist.xaml
    /// </summary>
    public partial class ArtistView : Window
    {
        private ReviewSection reviewSection;

        public ArtistView(Artist artist)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = $"{artist.Name} {artist.LastName}";
            reviewSection = new ReviewSection(artist.AllStarRatings, artist.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
