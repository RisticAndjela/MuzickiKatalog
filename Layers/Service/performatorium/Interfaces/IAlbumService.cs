namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    using muzickiKatalog.Layers.Model.performatorium;

    public interface IAlbumService
    {
        public static void AddComment(Album album, Comment comment) { }
        public static void AddRating(Album album, StarRating stars) { }
        public static void Visited(Album album) {  }
        public static Dictionary<string, Album> Get10Popular() { return new Dictionary<string, Album>(); }

    }
}
