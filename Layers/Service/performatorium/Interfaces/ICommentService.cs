using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    public interface ICommentService
    {
        public static void AddToNeedApproveList(Comment comment) { }
        public static void Approved(Comment comment) { }
    }
}
