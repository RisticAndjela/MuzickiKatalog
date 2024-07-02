using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using model=muzickiKatalog.Layers.Model.performatorium;
using System.Windows;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for Material.xaml
    /// </summary>
    public partial class MaterialView : Window
    {
        private ReviewSection reviewSection;

        public MaterialView(model.Material material)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content= material.Title;
            reviewSection = new ReviewSection(material.AllStarRatings, material.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
