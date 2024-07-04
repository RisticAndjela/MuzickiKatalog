using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Material: IMaterial
    {
        public string Editor {  get; set; }
        public string Title {  get; set; }
        public DateOnly PublishDate { get; set; }
        public DateOnly PerformedDate { get; set; }
        public List<string> Genres {  get; set; }
        public string Albums { get; set; } = null;
        public List<string> Contributors {  get; set; }= new List<string>(); //ids of Artists
        public List<string> Media {  get; set; }= new List<string>(); 
        public List<Comment> AllComments { get; set; } = new List<Comment>();
        public List<StarRating> AllStarRatings { get; set; } = new List<StarRating>();
        public int Visits {  get; set; } = 0;
        public Material() { }

        public Material(string _editor,string _title, List<string> _genres, DateOnly _publishDate, DateOnly _performedDate, List<string> _contributors, List<string> _media, string _description)
        {
            Editor = _editor;
            Title = _title;
            Genres = _genres;
            Media = _media;
            PublishDate = _publishDate;
            PerformedDate = _performedDate;
            Contributors = _contributors;
            new Text(_description, MakeIDs.makeMaterialID(this));
            MaterialRepository.save(this);
        }

       
    }
}
