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
using System.Windows.Navigation;
using muzickiKatalog.Layers.Service.performatorium;
using contributor = muzickiKatalog.Layers.Model.contributors;
using System.Windows.Shapes;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
using muzickiKatalog.Layers.Controller.performatorium;

namespace muzickiKatalog.GUI.MVVM.View.UserControls
{
    /// <summary>
    /// Interaction logic for PlayListUserControl.xaml
    /// </summary>
    public partial class PlayListUserControl : UserControl
    {
        private PlayList playlist;
        public PlayListUserControl(PlayList playlist, contributor.Member member)
        {
            InitializeComponent();
            isVisible.Content = playlist.isPrivate ? "PUBLIC" : "PRIVATE";
            naslovLabela.Content = playlist.Name;
            this.playlist = playlist;
            if (member.username == playlist.owner)
            {
                isVisible.Visibility= Visibility.Visible;
            }
            (Dictionary<string, Tuple<string, string>> albumsDict,Dictionary<string, Tuple<string, string>> materialsDict)=PlayListController.getAllAlbumsAndMaterials(playlist);
            new InsertOneListBasedOnUser(member).insert(materials, materialsDict,"Material", null);
            new InsertOneListBasedOnUser(member).insert(albums, albumsDict,"Album", null);
        }
        private void privateButton(object sender, RoutedEventArgs e)
        {
            PlayListService.changeVisibility(playlist);
            isVisible.Content = playlist.isPrivate ? "PUBLIC": "PRIVATE" ;
        }
    }
}
