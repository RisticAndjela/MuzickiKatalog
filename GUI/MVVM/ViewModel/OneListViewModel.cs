using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace muzickiKatalog.GUI.MVVM.ViewModel
{
    public class OneListViewModel : INotifyPropertyChanged
    {
        private UserControl listViewMaterials;
        private UserControl listViewAlbums;
        private UserControl listViewArtists;
        private UserControl listViewGroups;

        public OneListViewModel(Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_)
        {
            
            ListShowMaterials = new OneList(MaterialController.getForList(materials_),typeof(Material));
            
            ListShowAlbums = new OneList(AlbumController.getForList(albums_), typeof(Album));
            
            ListShowArtists = new OneList(ArtistController.getForList(artists_), typeof(Artist));
           
            ListShowGroups = new OneList(GroupController.getForList(groups_), typeof(Group));

        }

        public UserControl ListShowMaterials
        {
            get { return listViewMaterials; }
            set
            {
                listViewMaterials = value;
                OnPropertyChanged();
            }
        }
        public UserControl ListShowAlbums
        {
            get { return listViewAlbums; }
            set
            {
                listViewAlbums = value;
                OnPropertyChanged();
            }
        }
        public UserControl ListShowArtists
        {
            get { return listViewArtists; }
            set
            {
                listViewArtists = value;
                OnPropertyChanged();
            }
        }
        public UserControl ListShowGroups
        {
            get { return listViewGroups; }
            set
            {
                listViewGroups = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}