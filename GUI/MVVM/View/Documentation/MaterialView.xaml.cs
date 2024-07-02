using muzickiKatalog.GUI.MVVM.View.Controls;
using muzickiKatalog.GUI.MVVM.ViewModel;
using model=muzickiKatalog.Layers.Model.performatorium;
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
    /// Interaction logic for Material.xaml
    /// </summary>
    public partial class MaterialView : Window
    {
        private ReviewSection reviewSection;

        public MaterialView(model.Material material)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            naslovLabela.Content= material.title;
            reviewSection = new ReviewSection(material.starRatings, material.comments);
            ControlsViewModel viewModel = new ControlsViewModel();
            DataContext = viewModel;
            panelr.Content = reviewSection;
        }
    }
}
