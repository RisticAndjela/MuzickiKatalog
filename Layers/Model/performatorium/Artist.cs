using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Model.contributors.Interfaces;
using muzickiKatalog.Layers.Model.contributors;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Artist : IPerson,IArtist
    {
        public string Editor {  get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender GenderProp { get; set; }
        public DateOnly Birthday { get; set; }

        public artistType Type { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> Groups { get; set; } = new List<string>();
        public List<string> Media { get; set; } = new List<string>();
        public List<string> AllMaterials { get; set; } = new List<string>();
        public List<Comment> AllComments { get; set; }= new List<Comment>();
        public List<StarRating> AllStarRatings { get; set; }= new List<StarRating>();
        public int Visits {  get; set; } = 0;
        public Artist() { }
        public Artist(string _editor,string _name, string _lastName, Gender _gender, DateOnly _birthday, string _biography, artistType _type,List<string> _genres, List<string> _media)
        {
            Name = _name;
            LastName = _lastName;
            GenderProp = _gender;
            Birthday = _birthday;

            Editor = _editor;
            Type=_type;
            Media = _media;
            Genres = _genres;
            Type = _type;
            new Text(_biography, MakeIDs.makeArtistID(this));
            ArtistRepository.save(this);
        }
       
        
    }
}
