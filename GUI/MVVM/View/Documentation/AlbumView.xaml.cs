using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Controller.performatorium;
using System.Windows;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumView : Window
    {
        private ReviewSection reviewSection;
        private Album album;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        public AlbumView(Album _album,Dictionary<string,Material> allMaterials,Dictionary<string,Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            InitializeComponent();
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            album = _album;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = album.Name;
            reviewSection = new ReviewSection(album.AllStarRatings,album.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content=reviewSection;
            fillContents();
        }
       
        public void fillContents()
        {
            Dictionary<string, Tuple<string, string>> similarDict =AlbumController.FindAlbumsFromSameArtist(album, allAlbums, allArtists, allMaterials);
            Dictionary<string, Tuple<string, string>> fromArtistDict =MaterialController.FindMaterialsBasedOnAlbum(album,allMaterials,allArtists);
            _=similarDict.Count > 0 ? similarAlbums.Content = new OneList(similarDict, "Album") : similarLabel.Visibility = Visibility.Hidden;
            _= fromArtistDict.Count > 0 ? fromArtists.Content = new OneList(fromArtistDict, "Material") : sameArtistLabel.Visibility = Visibility.Hidden;
            fillMain();
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Album>.getGalleryImages(album);
            _= galleryDict.Count > 0 ? gallery.Content = new OneList(galleryDict, "none") : galleryLabel.Visibility = Visibility.Hidden;

        }

        public void fillMain()
        {
            main.Children.Clear();
            ButtonLabelManipulation.fillDescription(album.Description,main,this);
            ButtonLabelManipulation.fillDescription($"GENRE:  {album.Genre}", main,this);

            
            List<Artist> artists = new List<Artist>();
            foreach (string materialString in album.AllMaterials)
            {
                Material material = GetFromIDs<Material>.get(materialString, GlobalVariables.materialsFile).Item2;

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

                ButtonLabelManipulation.AddButtonToPanel(column1, material.Title, (sender, e) => new MaterialView(material, allMaterials, allAlbums, allArtists, allGroups).Show(),this);
            }

           

        }
        void AddArtistIfNotExists(List<Artist> artists, Artist artistToAdd)
        {
            if (!artists.Any(a => $"{a.Name} {a.LastName}" == $"{artistToAdd.Name} {artistToAdd.LastName}"))
            {
                artists.Add(artistToAdd);
                ButtonLabelManipulation.AddButtonToPanel(column2, $"{artistToAdd.Type}: {artistToAdd.Name} {artistToAdd.LastName}", (sender, e) => new ArtistView(artistToAdd,allMaterials,allAlbums,allArtists,allGroups).Show(),this);
            }
        }

       
    }
}
