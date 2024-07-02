using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using System.Windows;
using model=muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for Genre.xaml
    /// </summary>
    public partial class GenreView : Window
    {
        private ReviewSection reviewSection;

        public GenreView(model.Genre genre)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = genre.Name;
            reviewSection = new ReviewSection(null,null);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
