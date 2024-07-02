using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;


namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Group : IGroup
    {
        public string Name {  get; set; }
        public DateOnly Started {  get; set; }
        public bool isActive {  get; set; }
        public List<string> Artists { get; set; } = new List<string>();
        public List<string> AllMaterials { get; set; }= new List<string>();
        public List<string> Media { get; set; }= new List<string>();
        public List<Comment> AllComments {  get; set; }=new List<Comment>();
        public List<StarRating> AllStarRatings { get; set; } = new List<StarRating>();
        public int Visits { get; set; } = 0;

        public Group() { }
        public Group(string _name,DateOnly _started, bool _active,List<string> _artists, List<string> _media, string description)
        {
            Artists = _artists;
            Media = _media;
            Name=_name;
            Started=_started;
            isActive=_active;
            new Text(description, MakeIDs.makeGroupID(this));
            GroupRepository.save(this);
        }
       

        
    }
}
