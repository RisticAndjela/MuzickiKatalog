using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.Model.contributors.Interfaces;
namespace muzickiKatalog.Layers.Model.contributors
{
    public class Editor : IPerson
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender GenderProp { get; set; }
        public DateOnly Birthday { get; set; }

        public List<string> genres { get; set; }= new List<string>();
        public List<Comment> needToApproveComments { get; set; } = new List<Comment>();
        public List<StarRating> needToApproveRatings { get; set; } = new List<StarRating>();
        public List<string> needToLeaveReviews { get; set; }=new List<string>();
        public Editor() { }
        public Editor(string _username, string _password, string _name, string _lastName, Gender _gender, DateOnly _birthday,List<string> _genres) 
        {
            Username= _username;
            new User(_username, _password, personType.editor);
            Name = _name;
            LastName = _lastName;
            GenderProp = _gender;
            Birthday = _birthday;

            genres = _genres;
            save();
        }
        public void save()
        {
            SaveOneInstance<Editor>.SaveOneInstanceInDictionary(this, Username, GlobalVariables.editorsFile);
        }

        public void addComment(Comment comment)
        {
            needToApproveComments.Add(comment);
            save();
        }
        public void addRating(StarRating rating) { 
            needToApproveRatings.Add(rating);
            save();
        }
        public void approvedComment (Comment comment)
        {
            needToApproveComments.Remove(comment);
            save();
            CommentService.Approved(comment);
        }
        public void disapprovedComment(Comment comment) {
            needToApproveComments.Remove(comment);
            save();
        }
        public void approvedRating(StarRating rating)
        {
            needToApproveRatings.Remove(rating);
            save();
            StarRatingService.Approved(rating);
        }
        public void disapprovedRating(StarRating rating)
        {
            needToApproveRatings.Remove(rating);
            save();
        }
        public void haveToleaveReviewOn(string id)
        {
            needToLeaveReviews.Add(id);
            save();
        }
        public void leftReviewAsAsked(string id)
        {
            needToLeaveReviews.Remove(id);
            save();
        }
    }
}
