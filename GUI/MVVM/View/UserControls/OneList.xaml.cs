using muzickiKatalog.GUI.MVVM.View.Documentation;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
using contributor=muzickiKatalog.Layers.Model.contributors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for OneList.xaml
    /// </summary>
    public partial class OneList : UserControl
    {
        public Dictionary<string, Tuple<string, string>> all = new Dictionary<string, Tuple<string, string>>();
        public int indexOfCurrentFirst { get; set; } = 0;
        public string type { get; set; }
        OneListViewModel vm;
        public OneList(Dictionary<string, Tuple<string, string>> _all, string _type)
        {
            InitializeComponent();
            all = _all;
            type = _type;
            vm=new OneListViewModel(this);
            DataContext = vm;
            fillTableWithData(all);
        }
        public OneList(contributor.Editor editor,Dictionary<string, Tuple<string, string>> _all, string _type)
        {
            InitializeComponent();
            all = _all;
            type = _type;
            vm=new OneListViewModel(this,editor);
            DataContext = vm;
            fillTableWithData(all);
        }
        public OneList(contributor.Member member,Dictionary<string, Tuple<string, string>> _all, string _type)
        {
            InitializeComponent();
            all = _all;
            type = _type;
            vm=new OneListViewModel(this,member);
            DataContext = vm;
            fillTableWithData(all);
        }
        
        private void ButtonNextPage(object sender, RoutedEventArgs e)
        {
            indexOfCurrentFirst++;
            fillTableWithData(all);
        }
        private void open(object sender, RoutedEventArgs e)
        {
            if (sender is Button button) { 
                vm.open(button.Tag.ToString(),type);
            }
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
                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(items[key].Item2, UriKind.RelativeOrAbsolute);
                        bitmap.DecodePixelWidth = 120;
                        bitmap.DecodePixelHeight = 90;
                        bitmap.EndInit();
                        image.Source = bitmap;
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        
                        Console.WriteLine($"Directory not found: {ex.Message}");
                        
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
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
