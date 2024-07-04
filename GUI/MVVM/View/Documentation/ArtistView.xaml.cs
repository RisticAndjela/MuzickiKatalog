using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
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

        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;

        public ArtistView(Artist artist, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
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
            Dictionary<string, Tuple<string, string>> albumDicti = AlbumController.allAlbumsForArtist(artist, allAlbums, allArtists, allMaterials);
            Dictionary<string, Tuple<string, string>> materialsDicti = MaterialController.FindMaterialsFromSameArtist(artist, allMaterials);
            similar.Content = similarDicti.Count > 0 ? new OneList(similarDicti, "Artist") : null;
            _ = similarDicti.Count > 0 ? similar.Content = new OneList(similarDicti, "Artist") : similarLabel.Content = "";
            albums.Content = albumDicti.Count > 0 ? new OneList(albumDicti, "Album") : null;
            materials.Content = materialsDicti.Count > 0 ? new OneList(materialsDicti, "Material") : null;
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
                ButtonLabelManipulation.AddButtonToPanel(genres, genre.Name, (sender, e) => new GenreView(genre), this);
            }
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Artist>.getGalleryImages(artist);
            _ = galleryDict.Count > 0 ? gallery.Content = new OneList(galleryDict, "none") : galleryLabel.Content = "";
        }

    }
}
