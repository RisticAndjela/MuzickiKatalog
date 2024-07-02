using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    public interface IGenreService
    {
        public static void AddMaterial(Genre genre, Material material) { }
        public static void AddAlbum(Genre genre, Album album) { }
        public static void AddComment(Genre genre, Comment comment) { }
        public static void AddRating(Genre genre, StarRating stars) { }
    }
}
