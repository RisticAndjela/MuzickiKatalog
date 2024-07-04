using System.Windows.Controls;
using muzickiKatalog.Layers.Model.performatorium;
using contributor=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.GUI.MVVM.ViewModel;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for Listed.xaml
    /// </summary>
    public partial class Listed : UserControl
    {
        ListedViewModel viewModel;
        public Listed( Dictionary<string,Material> materials_,Dictionary<string,Album> albums_,Dictionary<string,Group> groups_,Dictionary<string,Artist> artists_)
        {
            InitializeComponent();
            viewModel = new ListedViewModel(materials_,albums_,groups_,artists_);
            materials.Content = viewModel.ListShowMaterials;
            DataContext = viewModel;
        }
        public Listed(contributor.Editor editor,Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_)
        {
            InitializeComponent();
            viewModel = new ListedViewModel(editor, materials_, albums_, groups_, artists_);
            materials.Content= viewModel.ListShowMaterials;
            DataContext = viewModel;
        }
        public Listed(contributor.Member member, Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_)
        {
            InitializeComponent();
            viewModel = new ListedViewModel(member, materials_, albums_, groups_, artists_);
            materials.Content=viewModel.ListShowMaterials;
            DataContext = viewModel;
        }
    }
}
