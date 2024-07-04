using muzickiKatalog.GUI.MVVM.View.Documentation;
using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using contributor=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace muzickiKatalog.GUI.MVVM.ViewModel
{
    public class ListedViewModel : INotifyPropertyChanged
    {
    private UserControl listViewMaterials;
    private UserControl listViewAlbums;
    private UserControl listViewArtists;
    private UserControl listViewGroups;
        public ListedViewModel(Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_) {
            ListShowMaterials = new OneList(MaterialController.getForList(materials_), "Material");

            ListShowAlbums = new OneList(AlbumController.getForList(albums_), "Album");

            ListShowArtists = new OneList(ArtistController.getForList(artists_), "Artist");

            ListShowGroups = new OneList( GroupController.getForList(groups_), "Group");
        }
          public ListedViewModel(contributor.Member member,Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_) {
            ListShowMaterials = new OneList(member,MaterialController.getForList(materials_), "Material");

            ListShowAlbums = new OneList(member, AlbumController.getForList(albums_), "Album");

            ListShowArtists = new OneList(member, ArtistController.getForList(artists_), "Artist");

            ListShowGroups = new OneList(member, GroupController.getForList(groups_), "Group");
        }
          public ListedViewModel(contributor.Editor editor,Dictionary<string, Material> materials_, Dictionary<string, Album> albums_, Dictionary<string, Group> groups_, Dictionary<string, Artist> artists_) {
            ListShowMaterials = new OneList(editor,MaterialController.getForList(materials_), "Material");

            ListShowAlbums = new OneList(editor, AlbumController.getForList(albums_), "Album");

            ListShowArtists = new OneList(editor, ArtistController.getForList(artists_), "Artist");

            ListShowGroups = new OneList(editor, GroupController.getForList(groups_), "Group");
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
