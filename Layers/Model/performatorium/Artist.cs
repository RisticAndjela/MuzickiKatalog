using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Artist : Person,IArtist
    {
        public string Editor {  get; set; }
        public artistType Type { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
        public List<string> Groups { get; set; } = new List<string>();
        public List<string> Media { get; set; } = new List<string>();
        public List<string> AllMaterials { get; set; } = new List<string>();
        public List<Comment> AllComments { get; set; }= new List<Comment>();
        public List<StarRating> AllStarRatings { get; set; }= new List<StarRating>();
        public int Visits {  get; set; } = 0;
        public Artist() { }
        public Artist(string _editor,string _name, string _lastName, Gender _gender, DateOnly _birthday, string _biography, artistType _type,List<string> _genres, List<string> _media) : base("", "",_name, _lastName, _gender, _birthday, personType.artist)
        {
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
