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

namespace muzickiKatalog.GUI.MVVM.View.Controls
{
    /// <summary>
    /// Interaction logic for OneList.xaml
    /// </summary>
    public partial class OneList : UserControl
    {
        public Dictionary<string, Tuple<string, string>> all = new Dictionary<string, Tuple<string, string>>();
        public int numberOfPage { get; set; } = 0;
        public int numberOfItemsOnPage { get; set; } = 0;

        public OneList(Dictionary<string, Tuple<string, string>> _all)
        {
            InitializeComponent();
            all = _all;
            fillTableWithData(all);
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
