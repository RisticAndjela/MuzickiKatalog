using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using contributor=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
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

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for ArtistView.xaml
    /// </summary>
    public partial class ArtistView : Window
    {
        private ReviewSection reviewSection;
        private Artist artist;
        public OpenViewBasedOnUser nextView;
        public InsertOneListBasedOnUser oneLineInsert;
        private string user;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        private bool isAbleToEdit = false;
        public void View(Artist artist, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            this.artist = artist;
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = $"{artist.Name} {artist.LastName}";
            reviewSection = new ReviewSection(artist.AllStarRatings, artist.AllComments);
            panelr.Content = reviewSection;

        }
        public ArtistView(Artist _artist, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            user = "guest";
            nextView = new OpenViewBasedOnUser();
            oneLineInsert = new InsertOneListBasedOnUser();
            View(_artist,_allMaterials,_allAlbums,_allArtists,_allGroups);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            fillContents();
        }
        public ArtistView(contributor.Member member, Artist _artist, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            follow.Visibility = Visibility.Visible;
            user = "member";
            nextView = new OpenViewBasedOnUser(member);
            oneLineInsert= new InsertOneListBasedOnUser(member);
            View(_artist, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(member);
            DataContext = viewModel;
            fillContents();

        }
        public ArtistView(contributor.Editor editor, Artist _artist, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            if (artist.Editor == editor.Username) { isAbleToEdit = true; edit.Visibility = Visibility.Visible; }
            user = "editor";
            nextView = new OpenViewBasedOnUser(editor);
            oneLineInsert=new InsertOneListBasedOnUser(editor);
            View(_artist, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(editor);
            DataContext = viewModel;
            fillContents();
        }
        private void editButton(object sender, RoutedEventArgs e)
        {
        }
        private void followButton(object sender, RoutedEventArgs e)
        {

        }
        public void fillContents()
        {
            fillMain();
            Dictionary<string, Tuple<string, string>> similarDicti = ArtistController.FindArtistsWithSameGenre(artist, allArtists);
            Dictionary<string, Tuple<string, string>> albumDicti = AlbumController.allAlbumsForArtist(artist, allAlbums, allArtists, allMaterials);
            Dictionary<string, Tuple<string, string>> materialsDicti = MaterialController.FindMaterialsFromSameArtist(artist, allMaterials);
            oneLineInsert.insert(similar, similarDicti, "Artist", similarLabel);
            oneLineInsert.insert(albums, albumDicti, "Album", null);
            oneLineInsert.insert(materials, materialsDicti, "Material", null);
            materialsLabel.Content = materialsDicti.Count == 0 && albumDicti.Count == 0 ? "" : "MATERIALS FROM THIS ARTIST";
        }
        public void fillMain()
        {
            name.Content=artist.Name;
            lastName.Content = artist.LastName;
            gender.Content=artist.GenderProp.ToString();
            birthday.Content=artist.Birthday.ToString();
            string id = MakeIDs.makeArtistID(artist);
            ButtonLabelManipulation.fillDescription(GetFromIDs<Text>.get(id, GlobalVariables.textsFile).Item2.text, biography, this);
            foreach (string genreID in artist.Genres)
            {
                Genre genre = GetFromIDs<Genre>.get(genreID, GlobalVariables.genresFile).Item2;
                ButtonLabelManipulation.AddButtonToPanel(genres, genre.Name, (sender, e) => nextView.OpenGenreView(user,genre,allMaterials,allAlbums,allArtists,allGroups), this);
            }
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Artist>.getGalleryImages(artist);
            oneLineInsert.insert(gallery, galleryDict, "none", galleryLabel);
        }

    }
}
