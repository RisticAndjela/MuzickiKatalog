using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    public interface IGroupService
    {
        public static void Visited(Group group) { }
        public static void AddMaterial(Group group, Material material) { }
        public static void AddAlbum(Group group, Album album) { }
        public static void AddComment(Group group, Comment comment) { }
        public static void AddRating(Group group, StarRating stars) { }
        public static Dictionary<string, Group> Get10Popular() { return null; }
    }
}
