using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using contributor=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support;
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
    /// Interaction logic for MaterialView.xaml
    /// </summary>
    public partial class MaterialView : Window
    {
        private ReviewSection reviewSection;
        private Material material;
        private string user;
        private contributor.Editor editor;
        private contributor.Member member;
        public OpenViewBasedOnUser nextView;
        private InsertOneListBasedOnUser oneLineInsert;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        public bool isAbleToEdit = false;

        public void View(Material material, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            this.material = material;
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = material.Title;
            reviewSection = new ReviewSection(material.AllStarRatings, material.AllComments);
            panelr.Content = reviewSection;

        }
        public MaterialView(Material _material, Dictionary<string, Material> _allMaterials, Dictionary<string, Album>  _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            user = "guest";
            nextView=new OpenViewBasedOnUser();
            oneLineInsert = new InsertOneListBasedOnUser();
            View(_material,_allMaterials,_allAlbums,_allArtists,_allGroups);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            fillContents();
        }
        public MaterialView(contributor.Editor editor, Material _material, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            this.editor= editor;
            if (material.Editor == editor.Username) { isAbleToEdit = true; edit.Visibility = Visibility.Visible; }
            user = "editor";
            nextView = new OpenViewBasedOnUser(editor);
            oneLineInsert= new InsertOneListBasedOnUser(editor);
            View(_material, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(editor);
            DataContext = viewModel;
            fillContents();
        }
        public MaterialView(contributor.Member member, Material _material, Dictionary<string, Material> _allMaterials, Dictionary<string, Album> _allAlbums, Dictionary<string, Artist> _allArtists, Dictionary<string, Group> _allGroups)
        {
            InitializeComponent();
            this.member= member;
            addToPlaylist.Visibility = Visibility.Visible;
            user = "member";
            nextView=new OpenViewBasedOnUser(member);
            oneLineInsert=new InsertOneListBasedOnUser(member);
            View(_material, _allMaterials, _allAlbums, _allArtists, _allGroups);
            ControlsViewModel viewModel = new ControlsViewModel(member);
            DataContext = viewModel;
            fillContents();
        }
       
        private void addToPlaylistButton(object sender, RoutedEventArgs e)
        {

        }
        private void editButton(object sender, RoutedEventArgs e)
        {
        }
        public void fillContents()
        {
            fillMain();
            Dictionary<string, Tuple<string, string>> similarDicti = MaterialController.FindMaterialsWithSameGenre(material,allMaterials);//similar materials
            Dictionary<string, Tuple<string, string>> albumDicti = AlbumController.allAlbumsForSameArtists(material, allAlbums, allArtists, allMaterials); //from same artist
            Dictionary<string, Tuple<string, string>> materialsDicti = MaterialController.allMaterialsForSameArtists(material,allArtists ,allMaterials);//from same artist
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Material>.getGalleryImages(material);
            materialsLabel.Content = materialsDicti.Count == 0 && albumDicti.Count == 0 ? "" : "MATERIALS FROM THIS ARTIST";
            oneLineInsert.insert(gallery, galleryDict, "none", galleryLabel);
            oneLineInsert.insert(similar, similarDicti, "Material", similarLabel);
            oneLineInsert.insert(albums, albumDicti, "Album", null);
            oneLineInsert.insert(materials, materialsDicti, "Material", null);
        }
        public void fillMain()
        {
            PublishDate.Content = material.PublishDate.ToString();
            PerformedDate.Content = material.PerformedDate.ToString();
            if (string.IsNullOrEmpty(material.Albums)){partOfAlbum.Visibility=Visibility.Hidden;}
            else
            {
                ButtonLabelManipulation.AddButtonToPanel(partOfAlbum, material.Albums, (sender, e) => nextView.OpenAlbumView(user,GetFromIDs<Album>.get(material.Albums,GlobalVariables.albumsFile).Item2, allMaterials, allAlbums, allArtists, allGroups), this);
            }
            ButtonLabelManipulation.fillDescription(MaterialService.getDescription(material), description, this);
            List<Artist> artists = new List<Artist>();
            foreach (string genreID in material.Genres)
            {
                Genre genre = GetFromIDs<Genre>.get(genreID, GlobalVariables.genresFile).Item2;
                ButtonLabelManipulation.AddButtonToPanel(genres, genre.Name, (sender, e) => nextView.OpenGenreView(user,genre,allMaterials,allAlbums,allArtists,allGroups), this);
            }
            foreach (string contribute in material.Contributors)
            {
                if (allArtists.ContainsKey(contribute))
                {
                    AddArtistIfNotExists(artists, allArtists[contribute]);
                }
                else if (allGroups.ContainsKey(contribute))
                {
                    IEnumerable<Artist> groupArtists = allGroups[contribute].Artists
                        .Select(value => GetFromIDs<Artist>.get(value, GlobalVariables.artistsFile).Item2);

                    foreach (Artist artistToAdd in groupArtists)
                    {
                        AddArtistIfNotExists(artists, artistToAdd);
                    }
                }
            }
         }

        void AddArtistIfNotExists(List<Artist> artists, Artist artistToAdd)
        {
            if (!artists.Any(a => $"{a.Name} {a.LastName}" == $"{artistToAdd.Name} {artistToAdd.LastName}"))
            {
                artists.Add(artistToAdd);
                ButtonLabelManipulation.AddButtonToPanel(column1, $"{artistToAdd.Type}: {artistToAdd.Name} {artistToAdd.LastName}", (sender, e) => nextView.OpenArtistView(user,artistToAdd,allMaterials,allAlbums,allArtists,allGroups), this);
            }
        }

    }

}
