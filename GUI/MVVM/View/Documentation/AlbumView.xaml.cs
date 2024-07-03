using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Controller.performatorium;
using System.Windows;
using System.Windows.Controls;
using muzickiKatalog.Layers.support.IDparser;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace muzickiKatalog.GUI.MVVM.View.Documentation
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumView : Window
    {
        private ReviewSection reviewSection;
        private Album album;

        public AlbumView(Album _album,Dictionary<string,Material> allMaterials,Dictionary<string,Album> allAlbums)
        {
            InitializeComponent();
            album = _album;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = album.Name;
            reviewSection = new ReviewSection(album.AllStarRatings,album.AllComments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content=reviewSection;
            similarAlbums.Content = new OneList(AlbumController.FindAlbumsFromSameArtist(album, allAlbums),typeof(Album));
            fromArtists.Content = new OneList(MaterialController.FindMaterialsBasedOnAlbum(album,allMaterials), typeof(Material));
            fillMain();
            gallery.Content = new OneList(getGalleryImages(), typeof(string));
        }
        public Dictionary<string, Tuple<string,string>> getGalleryImages()
        {
            Dictionary<string, Tuple<string, string>> final= new Dictionary<string, Tuple<string, string>>();
            foreach (string s in album.Media)
            {
                final.Add("s",Tuple.Create( "",s));
            }
            return final;
        }
        public void fillDescription()
        {
            int length = album.Description.Length;
            int i = 0;
            while (i < length)
            {
                string content = album.Description.Substring(i, Math.Min(90, length - i));
                int back = 0;
                while (content.Length > 0 && content.Last() != ' ')
                {
                    content = content.Substring(0, content.Length - 1);
                    back++;
                }

                Label description = new Label
                {
                    Style = (Style)FindResource("regularLabel"),
                    Content = content
                };
                main.Children.Add(description);
                i += 90-back;
            }
        }

        public void fillMain()
        {
            main.Children.Clear();
            fillDescription();

            Label genre = new Label{
                    Style = (Style)FindResource("regularLabel"),
                    Content = $"GENRE:  {album.Genre}" 
                };
            main.Children.Add(genre);
            
            List<Artist> artists = new List<Artist>();
            Dictionary<string, Artist> allArtists = ArtistRepository.getAll();
            Dictionary<string, Group> allGroups = GroupRepository.getAll();
            foreach (string materialString in album.AllMaterials)
            {
                Material material = GetFromIDs<Material>.get(materialString,GlobalVariables.materialsFile).Item2;
                foreach (string contribute in material.Contributors)
                {
                    if (allArtists.ContainsKey(contribute))
                    {
                        var artistToAdd = allArtists[contribute];
                        if (!artists.Any(a => $"{a.Name} {a.LastName}" == $"{artistToAdd.Name} {artistToAdd.LastName}"))
                        {
                            artists.Add(artistToAdd);
                        }
                    }
                    else if (allGroups.ContainsKey(contribute))
                    {
                        var groupArtists = allGroups[contribute].Artists
                            .Select(value => GetFromIDs<Artist>.get(value, GlobalVariables.artistsFile).Item2);

                        foreach (var artistToAdd in groupArtists)
                        {
                            if (!artists.Any(a => $"{a.Name} {a.LastName}" == $"{artistToAdd.Name} {artistToAdd.LastName}"))
                            {
                                artists.Add(artistToAdd);
                            }
                        }
                    }
                }
                Button button1 = new Button
                {
                    Style = (Style)FindResource("LabelLikeButton"),
                    Content = $"{material.Title}"
                };
                button1.Click += (sender, e) =>
                {
                    new MaterialView(material).Show();
                };
                column1.Children.Add(button1);
            }
           
            foreach (Artist artist in artists)
            {
                Button button1 = new Button
                {
                    Style = (Style)FindResource("LabelLikeButton"),
                    Content = $"{artist.Type.ToString()}: {artist.Name} {artist.LastName}",
                };
                button1.Click += (sender, e) =>
                {
                    new ArtistView(artist).Show();
                };
                column2.Children.Add(button1);
            }
            
           
           
        }
    }
}
