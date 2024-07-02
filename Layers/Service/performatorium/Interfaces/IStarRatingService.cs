using muzickiKatalog.Layers.Model.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium.Interfaces
{
    public interface IStarRatingService
    {
        public static void AddToNeedApproveList(StarRating star) { }
        public static void Approved(StarRating star) { }
    }
}
