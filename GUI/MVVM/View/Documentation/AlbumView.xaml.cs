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
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Service.contributors;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumView : Window
    {
        private ReviewSection reviewSection;
        private Album album;
        private string user;
        private contributor.Member member;
        private contributor.Editor editor;
        public OpenViewBasedOnUser nextView;
        public InsertOneListBasedOnUser oneLineInsert;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        private bool isAbleToEdit=false;

        public void View(Album album, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            this.album = album;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = album.Name;
            reviewSection = new ReviewSection(album.AllStarRatings, album.AllComments);
            panelr.Content = reviewSection;

        }
        public AlbumView(Album _album, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            user = "guest";
            nextView = new OpenViewBasedOnUser();
            oneLineInsert = new InsertOneListBasedOnUser();
            View(_album,_allMaterials,_allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            fillContents();
        }
        public AlbumView(contributor.Member member, Album _album, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            addToPlaylist.Visibility = Visibility.Visible;
            user = "member";
            this.member = member;
            nextView = new OpenViewBasedOnUser(member);
            oneLineInsert = new InsertOneListBasedOnUser(member);
            View(_album, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(member);
            DataContext = viewModel;
            fillContents();
        }
        public AlbumView(contributor.Editor editor, Album _album, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            if (album.AllMaterials.Any(a=>allMaterials[a].Editor == editor.Username)) { isAbleToEdit = true; edit.Visibility = Visibility.Visible; }
            user = "editor";
            this.editor= editor;
            nextView=new OpenViewBasedOnUser(editor);
            oneLineInsert = new InsertOneListBasedOnUser(editor);
            View(_album, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(editor);
            DataContext = viewModel;
            fillContents();
        }
        private void editButton(object sender, RoutedEventArgs e)
        {
        }
        private void addToPlaylistButton(object sender, RoutedEventArgs e)
        {
            
        }
        public void fillContents()
        {
            Dictionary<string, Tuple<string, string>> similarDict = AlbumController.FindAlbumsFromSameArtist(album, allAlbums, allArtists, allMaterials);
            Dictionary<string, Tuple<string, string>> fromArtistDict = MaterialController.FindMaterialsBasedOnAlbum(album, allMaterials, allArtists);
            oneLineInsert.insert(similarAlbums, similarDict, "Album", similarLabel);
            oneLineInsert.insert(fromArtists, fromArtistDict, "Material", sameArtistLabel);
            fillMain();
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Album>.getGalleryImages(album);
            oneLineInsert.insert(gallery, galleryDict, "none", galleryLabel);

        }

        public void fillMain()
        {
            main.Children.Clear();
            ButtonLabelManipulation.fillDescription(album.Description, main, this);
            ButtonLabelManipulation.fillDescription($"GENRE:  {album.Genre}", main, this);

            List<Artist> artists = new List<Artist>();
            foreach (string materialString in album.AllMaterials)
            {
                Material material = GetFromIDs<Material>.get(materialString, GlobalVariables.materialsFile).Item2;
                foreach (string contribute in material.Contributors)
                {
                    if (allArtists.ContainsKey(contribute)) {AddArtistIfNotExists(artists, allArtists[contribute]);}
                    else if (allGroups.ContainsKey(contribute))
                    {
                        List<Artist> groupArtists = allGroups[contribute].Artists.Select(value => GetFromIDs<Artist>.get(value, GlobalVariables.artistsFile).Item2).ToList();
                        foreach (Artist artistToAdd in groupArtists){AddArtistIfNotExists(artists, artistToAdd); }
                    }
                }

                ButtonLabelManipulation.AddButtonToPanel(column1, material.Title, (sender, e) => nextView.OpenMaterialView(user,material, allMaterials, allAlbums, allArtists, allGroups), this);
            }



        }
        void AddArtistIfNotExists(List<Artist> artists, Artist artistToAdd)
        {
            if (!artists.Any(a => $"{a.Name} {a.LastName}" == $"{artistToAdd.Name} {artistToAdd.LastName}"))
            {
                artists.Add(artistToAdd);
                ButtonLabelManipulation.AddButtonToPanel(column2, $"{artistToAdd.Type}: {artistToAdd.Name} {artistToAdd.LastName}", (sender, e) => nextView.OpenArtistView(user,artistToAdd, allMaterials, allAlbums, allArtists, allGroups), this);
            }
        }


    }
}