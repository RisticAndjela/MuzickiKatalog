namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    using muzickiKatalog.Layers.Model.performatorium;

    public interface IAlbumService
    {
        public static void AddComment(Album album, Comment comment) { }
        public static void AddRating(Album album, StarRating stars) { }
        public static void Visited(Album album) {  }
    }
}
