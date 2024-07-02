using muzickiKatalog.Layers.Model.performatorium;
using System.Collections.Generic;

namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    public interface IArtistService
    {
        public static void AddGroupInfo(Artist artist, Group group) { }
        public static void AddMaterialInfo(Artist artist, Material material) { }
        public static void AddAlbumInfo(Artist artist, Album album) { }
        public static void AddGenreInfo(Artist artist, Genre genre) { }
        public static void LeaveComment(Artist artist, Comment comment) { }
        public static void LeaveRating(Artist artist, StarRating rating) { }
        public static void Visited(Artist artist) { }
        public static Dictionary<string, Artist> Get10Popular() => new Dictionary<string, Artist>();
        public static int CalculateRating(Artist artist) => 0;
    }
}
