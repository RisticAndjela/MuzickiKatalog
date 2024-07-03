using muzickiKatalog.GUI.MVVM.View.Documentation;
using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace muzickiKatalog.GUI.MVVM.ViewModel
{
    public class OneListViewModel : INotifyPropertyChanged
    {
        private OneList view;
        public Dictionary<string, Material> allMaterials = MaterialRepository.getAll();
        public Dictionary<string, Album> allAlbums = AlbumRepository.getAll();
        public Dictionary<string, Artist> allArtists = ArtistRepository.getAll();
        public Dictionary<string, Group> allGroups = GroupRepository.getAll();
        public OneListViewModel(OneList view)
        {
            this.view= view;
        }

        
        public void open(string key,string type)
        {

                if (view.all.ContainsKey(key))
                {
                    if (type == "Artist")
                    {
                        Artist artist = GetFromIDs<Artist>.get(key, GlobalVariables.artistsFile).Item2;
                        ArtistService.Visited(artist);
                        ArtistView view = new ArtistView(artist, allMaterials, allAlbums, allArtists, allGroups);
                        view.Show();
                    }
                    else if (type == "Group")
                    {
                        Group group = GetFromIDs<Group>.get(key, GlobalVariables.groupsFile).Item2;
                        GroupService.visited(group);
                        GroupView view = new GroupView(group, allMaterials, allAlbums, allArtists, allGroups);
                        view.Show();
                    }
                    else if (type == "Album")
                    {
                        Album album = GetFromIDs<Album>.get(key, GlobalVariables.albumsFile).Item2;
                        AlbumService.Visited(album);
                        AlbumView view = new AlbumView(album, allMaterials, allAlbums, allArtists, allGroups);
                        view.Show();
                    }
                    else if (type == "Material")
                    {
                        Material material = GetFromIDs<Material>.get(key, GlobalVariables.materialsFile).Item2;
                        MaterialService.Visited(material);
                        MaterialView view = new MaterialView(material, allMaterials, allAlbums, allArtists, allGroups);
                        view.Show();
                    }


                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}