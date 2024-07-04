using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using contributor = muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
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
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for GenreView.xaml
    /// </summary>
    public partial class GenreView : Window
    {
        private ReviewSection reviewSection;
        private Genre genre;
        private string user;
        public InsertOneListBasedOnUser oneLineInsert;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        private bool isAbleToEdit = true;
        public void View(Genre genre, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            this.genre = genre;
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = genre.Name;
            reviewSection = new ReviewSection(genre.AllStarRatings, genre.AllComments);
            panelr.Content = reviewSection;

        }
        public GenreView(Genre _genre, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            user = "guest";
            oneLineInsert = new InsertOneListBasedOnUser();
            View(_genre, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            fillContents();
        }
        public GenreView(contributor.Editor editor, Genre _genre, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            isAbleToEdit = true; edit.Visibility = Visibility.Visible;
            user = "editor";
            oneLineInsert = new InsertOneListBasedOnUser(editor);
            View(_genre, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(editor);
            DataContext = viewModel;
            fillContents();
        }
        public GenreView(contributor.Member member, Genre _genre, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            user = "member";
            oneLineInsert= new InsertOneListBasedOnUser(member);
            View(_genre, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(member);
            DataContext = viewModel;
            fillContents();
        }

        private void editButton(object sender, RoutedEventArgs e)
        {
        }
       
        public void fillContents()
        {
            Dictionary<string, Tuple<string, string>> materials = GenreController.MaterialsByGenres(genre,allMaterials);
            Dictionary<string, Tuple<string, string>> albums = GenreController.AlbumsByGenres(genre,allAlbums,allMaterials);
            Dictionary<string, Tuple<string, string>> artists = GenreController.ArtistsByGenres(genre,allArtists);
            Dictionary<string, Tuple<string, string>> groups = GenreController.GroupsByGenres(genre,allGroups,allArtists);
            oneLineInsert.insert(materialsPanel, materials, "Material", materialsLabel);
            oneLineInsert.insert(albumsPanel, albums, "Album", albumsLabel);
            oneLineInsert.insert(artistsPanel, artists, "Artist", artistsLabel);
            oneLineInsert.insert(groupsPanel, groups, "Group", groupsLabel);
        }
    }
}
