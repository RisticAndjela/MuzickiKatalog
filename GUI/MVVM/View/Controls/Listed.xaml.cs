using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.GUI.MVVM.ViewModel;

namespace muzickiKatalog.GUI.MVVM.View.Controls
{
    /// <summary>
    /// Interaction logic for Listed.xaml
    /// </summary>
    public partial class Listed : UserControl
    {
        public Listed(Dictionary<string,Material> materials_,Dictionary<string,Album> albums_,Dictionary<string,Group> groups_,Dictionary<string,Artist> artists_)
        {
            InitializeComponent();
            DataContext = new OneListViewModel(materials_,albums_,groups_,artists_);
        }
    }
}
