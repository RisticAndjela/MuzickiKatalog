using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using System.Windows;
using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for Group.xaml
    /// </summary>
    public partial class GroupView : Window
    {
        private ReviewSection reviewSection;

        public GroupView(Group group)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = group.Name;
            reviewSection = new ReviewSection(group.AllStarRatings, group.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
