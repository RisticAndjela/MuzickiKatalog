using muzickiKatalog.GUI.MVVM.View.Documentation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for OneList.xaml
    /// </summary>
    public partial class OneList : UserControl
    {
        public Dictionary<string, Tuple<string, string>> all = new Dictionary<string, Tuple<string, string>>();
        public int numberOfPage { get; set; } = 0;
        public int numberOfItemsOnPage { get; set; } = 0;
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
                        ArtistView view = new ArtistView(GetFromIDs<Artist>.get(key, GlobalVariables.artistsFile).Item2);
                        view.Show();
                    }
                    else if (type == typeof(Group))
                    {
                        GroupView view = new GroupView(GetFromIDs<Group>.get(key, GlobalVariables.groupsFile).Item2);
                        view.Show();
                    }
                    else if (type == typeof(Album))
                    {
                        AlbumView view = new AlbumView(GetFromIDs<Album>.get(key, GlobalVariables.albumsFile).Item2);
                        view.Show();
                    }
                    else if (type == typeof(Material))
                    {
                        MaterialView view = new MaterialView(GetFromIDs<Material>.get(key, GlobalVariables.materialsFile).Item2);
                        view.Show();
                    }
                    
                }
            }
        }
        private void ButtonNextPage(object sender, RoutedEventArgs e)
        {
            numberOfPage++;
            fillTableWithData(all);
        }
        private void ButtonPreviousPage(object sender, RoutedEventArgs e)
        {
            numberOfPage--;
            fillTableWithData(all);
        }

        public void fillTableWithData(Dictionary<string, Tuple<string, string>> items)
        {
            ClearAllLabels();
            int localCounter = 1;
            foreach (string key in items.Keys.Skip(numberOfPage).Take(4))
            {
                Label label = (Label)FindName($"label{localCounter}");
                label.Content = items[key].Item1;

                Image image = (Image)FindName($"image{localCounter}");
                if (image != null && !string.IsNullOrEmpty(items[key].Item2))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(items[key].Item2, UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();
                    image.Source = bitmap;
                }
                Button button = (Button)FindName($"picture{localCounter}");
                button.IsHitTestVisible = true; 
                button.Tag = key;
                localCounter++;
            }
            numberOfItemsOnPage = localCounter;
            UpdateNavigationButtons();
        }
        
        public void ClearAllLabels()
        {

            for (int i = 1; i <= 4; i++)
            {
                ((Label)FindName($"label{i}")).Content = "";
                Image image = (Image)FindName($"image{i}");
                if (image != null) image.Source = null;
                Button button = (Button)FindName($"picture{i}");
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4C443C"));
                button.BorderThickness = new Thickness(0);
            }
        }


        //making buttons disappear or appear based on number of page we are on
        private void UpdateNavigationButtons()
        {
            back.Content = numberOfPage > 0 ? "B" : null;
            int nextPageStartIndex = (numberOfPage + 1) * 4;
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
