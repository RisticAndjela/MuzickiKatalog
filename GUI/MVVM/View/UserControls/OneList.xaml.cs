using muzickiKatalog.GUI.MVVM.View.Documentation;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for OneList.xaml
    /// </summary>
    public partial class OneList : UserControl
    {
        public Dictionary<string, Tuple<string, string>> all = new Dictionary<string, Tuple<string, string>>();
        public int indexOfCurrentFirst { get; set; } = 0;
        public Type type { get; set; }

        public OneList(Dictionary<string, Tuple<string, string>> _all, Type _type)
        {
            InitializeComponent();
            all = _all;
            type = _type;
            fillTableWithData(all);
        }
        private void open(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                string key = button.Tag as string;
                if (all.ContainsKey(key))
                {
                    if (type == typeof(Artist))
                    {
                        Artist artist = GetFromIDs<Artist>.get(key, GlobalVariables.artistsFile).Item2;
                        ArtistService.Visited(artist);
                        ArtistView view = new ArtistView(artist);
                        view.Show();
                    }
                    else if (type == typeof(Group))
                    {
                        Group group =GetFromIDs<Group>.get(key, GlobalVariables.groupsFile).Item2;
                        GroupService.visited(group);
                        GroupView view = new GroupView(group);
                        view.Show();
                    }
                    else if (type == typeof(Album))
                    {
                        Album album =GetFromIDs<Album>.get(key, GlobalVariables.albumsFile).Item2;
                        AlbumService.Visited(album);
                        AlbumView view = new AlbumView(album,MaterialRepository.getAll(),AlbumRepository.getAll());
                        view.Show();
                    }
                    else if (type == typeof(Material))
                    {
                        Material material =GetFromIDs<Material>.get(key, GlobalVariables.materialsFile).Item2;
                        MaterialService.Visited(material);
                        MaterialView view = new MaterialView(material);
                        view.Show();
                    }

                    
                }
            }
        }
        private void ButtonNextPage(object sender, RoutedEventArgs e)
        {
            indexOfCurrentFirst++;
            fillTableWithData(all);
        }
        private void ButtonPreviousPage(object sender, RoutedEventArgs e)
        {
            indexOfCurrentFirst--;
            fillTableWithData(all);
        }

        public void fillTableWithData(Dictionary<string, Tuple<string, string>> items)
        {
            ClearAllLabels();

            int localCounter = 1;
            foreach (string key in items.Keys.Skip(indexOfCurrentFirst))
            {
                Label label = (Label)FindName($"label{localCounter}");
                if (label != null)
                {
                    label.Content = items[key].Item1;
                }

                Image image = (Image)FindName($"image{localCounter}");
                if (image != null && !string.IsNullOrEmpty(items[key].Item2))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(items[key].Item2, UriKind.RelativeOrAbsolute);
                    bitmap.DecodePixelWidth = 120;
                    bitmap.DecodePixelHeight = 90;
                    bitmap.EndInit();
                    image.Source = bitmap;
                }

                Button button = (Button)FindName($"picture{localCounter}");
                if (button != null)
                {
                    button.IsHitTestVisible = true;
                    button.Tag = key;
                }

                localCounter++;
            }

            
            UpdateNavigationButtons();
        }


        public void ClearAllLabels()
        {

            for (int i = 1; i <= 4; i++)
            {
                ClearOneLabel(i);
            }
        }
        public void ClearOneLabel(int i)
        {
            ((Label)FindName($"label{i}")).Content = "";
            Image image = (Image)FindName($"image{i}");
            if (image != null) image.Source = null;
            Button button = (Button)FindName($"picture{i}");
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4C443C"));
            button.BorderThickness = new Thickness(0);
        }

        //making buttons disappear or appear based on number of page we are on
        private void UpdateNavigationButtons()
        {
            back.Content = indexOfCurrentFirst > 0 ? "B" : null;
            int nextPageStartIndex = indexOfCurrentFirst + 4;
            if (nextPageStartIndex < all.Count)
            {
                forward.Content = "N";
                forward.IsEnabled = true;
            }
            else
            {
                forward.Content = null;
                forward.IsEnabled = false;
            }
        }


    }
}
