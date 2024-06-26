using muzickiKatalog.Model.support;
using muzickiKatalog.Model.dao;
using muzickiKatalog.Model.Domain.performatorium;
namespace muzickiKatalog.Model.Domain.contributors
{
    public class Member : Person
    {
        public string username;
        public List<Comment> leftComments { get; set; } = new List<Comment>();
        public List<StarRating> leftRatings { get; set; } = new List<StarRating>();
        public Member() { }
        public Member(string _username, string password,string _name, string _lastName, Gender _gender, DateOnly _birthday) : base(_username, password,_name, _lastName, _gender, _birthday,personType.member)
        {
            username = _username;
            save();
        }
        public void save()
        {
            SaveOneInstance<Member>.SaveOneInstanceInDictionary(this, username, GlobalVariables.membersFile);
        }
        public void LeaveComment(Comment comment)
        {
            leftComments.Add(comment);
            save();
        }
        public void LeaveRating(StarRating starRating)
        {
            leftRatings.Add(starRating);
            save();
        }
    }
}
