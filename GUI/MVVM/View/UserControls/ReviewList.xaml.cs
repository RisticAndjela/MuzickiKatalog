using muzickiKatalog.GUI.MVVM.ViewModel;
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
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using contributor=muzickiKatalog.Layers.Model.contributors;
using System.Windows.Controls.Primitives;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for ReviewList.xaml
    /// </summary>
    public partial class ReviewList : UserControl
    {
        public Dictionary<string, Tuple<string, string>> all = new Dictionary<string, Tuple<string, string>>();
        public int indexOfCurrentFirst { get; set; } = 0;
        public string type { get; set; }
        private OneListViewModel vm;
        public ReviewList(contributor.Editor editor, Dictionary<string, Tuple<string, string>> _all, string _type)
        {
            InitializeComponent();
            all = _all;
            type = _type;
            vm = new OneListViewModel(this,editor);
            DataContext = vm;
            fillTableWithData(all);
            commentTask.Visibility= Visibility.Hidden;
            starTask.Visibility= Visibility.Hidden;
        }
         public ReviewList(contributor.Editor editor, Dictionary<string, Tuple<string, string>> _all, string _type,bool task)
        {
            InitializeComponent();
            all = _all;
            type = _type;
            vm = new OneListViewModel(this,editor,true);
            DataContext = vm;
            fillTableWithData(all);

        }

        private void ButtonNextPage(object sender, RoutedEventArgs e)
        {
            if (indexOfCurrentFirst < all.Count - 1)
            {
                indexOfCurrentFirst++;
                fillTableWithData(all);
            }
        }

        private void open(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                vm.open(button.Tag.ToString(), type);
            }
        }

        private void ButtonPreviousPage(object sender, RoutedEventArgs e)
        {
            if (indexOfCurrentFirst > 0)
            {
                indexOfCurrentFirst--;
                fillTableWithData(all);
            }
        }

        public void fillTableWithData(Dictionary<string, Tuple<string, string>> items)
        {
            ClearAllLabels();

            if (indexOfCurrentFirst < items.Count)
            {
                string key = items.Keys.ElementAt(indexOfCurrentFirst);
                ButtonLabelManipulation.fillDescription(items[key].Item1,label, this);

                if (FindName("image") is Image image && !string.IsNullOrEmpty(items[key].Item2))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(items[key].Item2, UriKind.RelativeOrAbsolute);
                    bitmap.DecodePixelWidth = 120;
                    bitmap.DecodePixelHeight = 90;
                    bitmap.EndInit();
                    image.Source = bitmap;
                }

                if (FindName("picture") is Button button)
                {
                    button.IsHitTestVisible = true;
                    button.Tag = key;
                }
            }

            UpdateNavigationButtons();
        }

        public void ClearAllLabels()
        {
            ClearOneLabel();
        }

        public void ClearOneLabel()
        {
            if (FindName("label") is Label label)
            {
                label.Content = "";
            }

            if (FindName("image") is Image image)
            {
                image.Source = null;
            }

            if (FindName("picture") is Button button)
            {
                button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4C443C"));
                button.BorderThickness = new Thickness(0);
            }
        }

        private void UpdateNavigationButtons()
        {
            back.Content = indexOfCurrentFirst > 0 ? "B" : null;
            back.IsEnabled = indexOfCurrentFirst > 0;

            forward.Content = indexOfCurrentFirst < all.Count - 1 ? "N" : null;
            forward.IsEnabled = indexOfCurrentFirst < all.Count - 1;
        }
        private void Star_Click(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                string starName = button.Name;
                int starNumber = int.Parse(starName.Substring(4));

                for (int i = 1; i <= 5; i++)
                {
                    ToggleButton star = FindName($"Star{i}") as ToggleButton;
                    if (star != null)
                    {
                        star.IsChecked = i <= starNumber;
                    }
                }
            }
        }


    }
}