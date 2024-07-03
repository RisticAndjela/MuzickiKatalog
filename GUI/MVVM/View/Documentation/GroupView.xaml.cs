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
        private Group thisGroup;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        public GroupView(Group group, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            InitializeComponent();
            thisGroup=group;
            this.allMaterials=allMaterials;
            this.allAlbums=allAlbums;
            this.allArtists=allArtists;
                this.allGroups=allGroups;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = group.Name;
            reviewSection = new ReviewSection(group.AllStarRatings, group.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
