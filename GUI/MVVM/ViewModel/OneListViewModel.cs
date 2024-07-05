using muzickiKatalog.GUI.MVVM.View.Documentation;
using muzickiKatalog.GUI.MVVM.View.UserControls;
using muzickiKatalog.GUI.MVVM.ViewModel.supportClasses;
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
    public class OneListViewModel : INotifyPropertyChanged
    {
        private OneList view;
        private ReviewList reviewView;
        private string user;
        private contributor.Editor editor;
        private contributor.Member member;

        public Dictionary<string, Material> allMaterials = MaterialRepository.getAll();
        public Dictionary<string, Album> allAlbums = AlbumRepository.getAll();
        public Dictionary<string, Artist> allArtists = ArtistRepository.getAll();
        public Dictionary<string, Group> allGroups = GroupRepository.getAll();
        public OneListViewModel(OneList view)
        {
            this.user= "guest";
            this.view= view;
        }
        public OneListViewModel(OneList view,contributor.Editor editor)
        {
            this.user= "editor";
            this.editor= editor;
            this.view= view;
        }
        public OneListViewModel(ReviewList view, contributor.Editor editor,bool task=false)
        {
            this.user = "editor";
            this.editor = editor;
            this.reviewView = view;
        }
        public OneListViewModel(OneList view,contributor.Member member)
        {
            this.user= "member";
            this.member= member;
            this.view= view;
        }

        
        public void open(string key,string type)
        {

            if ((view != null && view.all.ContainsKey(key)) || (reviewView!=null && reviewView.all.ContainsKey(key)));
            {
                if (type == "Artist")
                {
                    Artist artist = GetFromIDs<Artist>.get(key, GlobalVariables.artistsFile).Item2;
                    ArtistService.Visited(artist);
                    new OpenViewBasedOnUser(editor,member).OpenArtistView(user, artist, allMaterials, allAlbums, allArtists, allGroups);
                }
                else if (type == "Group")
                {
                    Group group = GetFromIDs<Group>.get(key, GlobalVariables.groupsFile).Item2;
                    GroupService.visited(group);
                    new OpenViewBasedOnUser(editor,member).OpenGroupView(user,group, allMaterials, allAlbums,allArtists, allGroups);
                }
                else if (type == "Album")
                {
                    Album album = GetFromIDs<Album>.get(key, GlobalVariables.albumsFile).Item2;
                    AlbumService.Visited(album);
                    new OpenViewBasedOnUser(editor, member).OpenAlbumView( user,album, allMaterials, allAlbums, allArtists, allGroups);
                }
                else if (type == "Material")
                {
                    Material material = GetFromIDs<Material>.get(key, GlobalVariables.materialsFile).Item2;
                    MaterialService.Visited(material);
                    new OpenViewBasedOnUser(editor, member).OpenMaterialView(user, material, allMaterials, allAlbums, allArtists, allGroups);
                }
                
            }
        }

        public void open()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}