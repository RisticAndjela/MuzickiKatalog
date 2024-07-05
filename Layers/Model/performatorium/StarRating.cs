using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;


namespace muzickiKatalog.Layers.Model.performatorium
{
    public class StarRating: IReview
    {
        public string reviewer { get; set; }
        public string idOfPlaceholder { get; set; }// id of biography or concert or wtvr 
        public int rating { get; set; }
        public DateTime reviewed { get; set; }

        public StarRating() { }
        public StarRating(string _reviewer, string _ratedOn, DateTime _reviewed, int _rating) {
            reviewer = _reviewer;
            rating = _rating;
            reviewed = _reviewed;
            idOfPlaceholder = _ratedOn;
            StarRatingService.AddToNeedApproveList(this);
        }

    }
}
