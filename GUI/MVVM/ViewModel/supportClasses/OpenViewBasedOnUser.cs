using muzickiKatalog.GUI.MVVM.View.Documentation;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.GUI.MVVM.ViewModel.supportClasses
{
    public class OpenViewBasedOnUser
    {
        public Editor editor {  get; set; }
        public Member member { get; set; }
        public OpenViewBasedOnUser() { }
        public OpenViewBasedOnUser(Editor editor) {
            this.editor = editor;
        }
        public OpenViewBasedOnUser(Member member) {
            this.member = member;
        }
          public OpenViewBasedOnUser(Editor editor,Member member) {
            this.member = member;
            this.editor = editor;
        }
         
        public void OpenAlbumView(string user,Album album, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups) {
            switch (user) {
                case "guest":
                    new AlbumView(album,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
                case "member":
                    new AlbumView(member,album,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
                case "editor":
                    new AlbumView(editor,album,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
            }

        } 
      
        public void OpenArtistView( string user,Artist artist, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups) {
            switch (user)
            {
                case "guest":
                    new ArtistView(artist,allMaterials,allAlbums, allArtists,allGroups).Show();
                    break;
                case "member":
                    new ArtistView(member,artist,allMaterials,allAlbums, allArtists,allGroups).Show();
                    break;
                case "editor":
                    new ArtistView(editor,artist,allMaterials,allAlbums, allArtists,allGroups).Show();
                    break;
            }
        }
      
        public void OpenGenreView(string user, Genre genre, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups) {
            switch (user)
            {
                case "guest":
                    new GenreView(genre,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
                case "member":
                    new GenreView(member,genre,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
                case "editor":
                    new GenreView(editor,genre,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
            }
        }
     
        public void OpenGroupView(string user, Group group, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups) {
            switch (user)
            {
                case "guest":
                    new GroupView(group,allMaterials,allAlbums, allArtists,allGroups).Show();
                    break;
                case "member":
                    new GroupView(member,group,allMaterials,allAlbums, allArtists,allGroups).Show();
                    break;
                case "editor":
                    new GroupView(editor,group,allMaterials,allAlbums, allArtists,allGroups).Show();
                    break;
            }
        }
        
        public void OpenMaterialView(string user,Material material, Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups) {
            switch (user)
            {
                case "guest":
                    new MaterialView(material,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
                case "member":
                    new MaterialView(member,material,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
                case "editor":
                    new MaterialView(editor,material,allMaterials,allAlbums,allArtists,allGroups).Show();
                    break;
            }
        }
       



    }
}
