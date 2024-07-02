using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    public interface IMaterialService
    {
        public static void LeaveRating(Material material, StarRating rating) { }
        public static void LeaveComment(Material material, Comment comment) { }
        public static void Visited(Material material) { }
        public static void PutInAlbum(Material material, string album) { }
        public static Dictionary<string, Material> Get10Popular() {  return new Dictionary<string, Material>(); }
    }
}
