using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.contributors.Interfaces;
namespace muzickiKatalog.Layers.Model.contributors
{
    public class Member : IPerson
    {
        public string username;

        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender GenderProp { get; set; }
        public DateOnly Birthday { get; set; }

        public List<Comment> leftComments { get; set; } = new List<Comment>();
        public List<StarRating> leftRatings { get; set; } = new List<StarRating>();
        public List<string> following {  get; set; }= new List<string>();
        public Member() { }
        public Member(string _username, string password,string _name, string _lastName, Gender _gender, DateOnly _birthday) 
        {
            username = _username;
            new User(username, password, personType.member);
            Name = _name;
            LastName = _lastName;
            GenderProp = _gender;
            Birthday = _birthday;
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

        public void follow(string id)
        {
            following.Add(id);
            save();
        }
    }
}
