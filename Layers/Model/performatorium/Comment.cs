using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Service.performatorium;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Comment: IReview
    {
        public string reviewer { get; set; }
        public string idOfPlaceholder {  get; set; }// id of biography or concert or wtvr 
        public string comment { get; set; }
        public DateTime reviewed { get; set; }
   
        public Comment() {}
        public Comment(string _reviewer, string _commentedOn_ID, DateTime _reviewed, string _comment)
        {
            reviewer = _reviewer;
            comment = _comment;
            reviewed = _reviewed;
            idOfPlaceholder = _commentedOn_ID;
            CommentService.AddToNeedApproveList(this);
        }
        

    }
}
