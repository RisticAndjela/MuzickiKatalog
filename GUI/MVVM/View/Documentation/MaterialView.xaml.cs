using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Service.performatorium;
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
    /// Interaction logic for MaterialView.xaml
    /// </summary>
    public partial class MaterialView : Window
    {
        private ReviewSection reviewSection;
        private Material material;
        public Dictionary<string, Material> allMaterials;
        public Dictionary<string, Album> allAlbums;
        public Dictionary<string, Artist> allArtists;
        public Dictionary<string, Group> allGroups;
        public MaterialView(Material material, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            InitializeComponent();
            this.material = material;
            this.allMaterials = allMaterials;
            this.allAlbums = allAlbums;
            this.allArtists = allArtists;
            this.allGroups = allGroups;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = material.Title;
            reviewSection = new ReviewSection(material.AllStarRatings, material.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
            fillContents();
            fillMain();
        }
        public void fillContents()
        {
            Dictionary<string, Tuple<string, string>> similarDicti = MaterialController.FindMaterialsWithSameGenre(material,allMaterials);//similar materials
            Dictionary<string, Tuple<string, string>> albumDicti = AlbumController.allAlbumsForSameArtists(material, allAlbums, allArtists, allMaterials); //from same artist
            Dictionary<string, Tuple<string, string>> materialsDicti = MaterialController.allMaterialsForSameArtists(material,allArtists ,allMaterials);//from same artist
            _ = similarDicti.Count > 0 ? similar.Content = new OneList(similarDicti, "Material") : similarLabel.Content = "";
            albums.Content = albumDicti.Count > 0 ? new OneList(albumDicti, "Album") : null;
            materials.Content = materialsDicti.Count > 0 ? new OneList(materialsDicti, "Material") : null;
            materialsLabel.Content = materialsDicti.Count == 0 && albumDicti.Count == 0 ? "" : "MATERIALS FROM THIS ARTIST";
            Dictionary<string, Tuple<string, string>> galleryDict = ConvertSupport<Material>.getGalleryImages(material);
            _ = galleryDict.Count > 0 ? gallery.Content = new OneList(galleryDict, "none") : galleryLabel.Content = "";
        }
        public void fillMain()
        {
            PublishDate.Content = material.PublishDate.ToString();
            PerformedDate.Content = material.PerformedDate.ToString();
            ButtonLabelManipulation.fillDescription(MaterialService.getDescription(material), description, this);
            List<Artist> artists = new List<Artist>();
            foreach (string genreID in material.Genres)
            {
                Genre genre = GetFromIDs<Genre>.get(genreID, GlobalVariables.genresFile).Item2;
                ButtonLabelManipulation.AddButtonToPanel(genres, genre.Name, (sender, e) => new GenreView(genre), this);
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
                ButtonLabelManipulation.AddButtonToPanel(column1, $"{artistToAdd.Type}: {artistToAdd.Name} {artistToAdd.LastName}", (sender, e) => new ArtistView(artistToAdd, allMaterials, allAlbums, allArtists, allGroups).Show(), this);
            }
        }

    }

}
