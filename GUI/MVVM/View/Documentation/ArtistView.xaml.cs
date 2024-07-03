using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
using materialNS=muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Controller.performatorium;
using System.Windows;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using System.Windows.Media.Media3D;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for Artist.xaml
    /// </summary>
    public partial class ArtistView : Window
    {
        private ReviewSection reviewSection;
        private Artist artist;

        public Dictionary<string, materialNS.Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;

        public ArtistView(Artist artist, Dictionary<string, materialNS.Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            this.artist = artist;
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = $"{artist.Name} {artist.LastName}";
            reviewSection = new ReviewSection(artist.AllStarRatings, artist.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
            fillMain();
            fillContents();
        }

        public void fillContents()
        {
            
            Dictionary<string, Tuple<string, string>> similarDicti = ArtistController.FindArtistsWithSameGenre(artist, allArtists);
            Dictionary<string, Tuple<string, string>> albumDicti =AlbumController.allAlbumsForArtist(artist,allAlbums,allArtists,allMaterials);
            Dictionary<string, Tuple<string, string>> materialsDicti =MaterialController.FindMaterialsFromSameArtist(artist, allMaterials);
            similar.Content = similarDicti.Count>0? new OneList(similarDicti, "Artist") :null;
            albums.Content= albumDicti.Count>0? new OneList(albumDicti, "Album") : null;
            materials.Content= materialsDicti.Count>0? new OneList(materialsDicti, "Material") :null;
        }
        public void fillMain()
        {
            string id = MakeIDs.makeArtistID(artist);
            ButtonLabelManipulation.fillDescription(GetFromIDs<Text>.get(id, GlobalVariables.textsFile).Item2.text,biography,this);
            foreach(string genreID in artist.Genres)
            {
                Genre genre = GetFromIDs<Genre>.get(genreID, GlobalVariables.genresFile).Item2;
                ButtonLabelManipulation.AddButtonToPanel(genres, genre.Name, (sender, e) => new GenreView(genre),this);
            }
        }

    }
}
