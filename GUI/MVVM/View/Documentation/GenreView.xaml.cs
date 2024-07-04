using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using muzickiKatalog.Layers.Model.performatorium;
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
    /// Interaction logic for GenreView.xaml
    /// </summary>
    public partial class GenreView : Window
    {
        private ReviewSection reviewSection;

        public GenreView(Genre genre)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content = genre.Name;
            reviewSection = new ReviewSection(null, null);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
