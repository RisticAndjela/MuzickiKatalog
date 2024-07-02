using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Album : IAlbum
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public List<string> Media { get; set; }=new List<string>();
        public List<string> AllMaterials { get; set; }=new List<string>();
        public List<Comment> AllComments { get; set; } = new List<Comment>();
        public List<StarRating> AllStarRatings { get; set; } = new List<StarRating>();
        public int Visits { get; set; } = 0;
        public Album() { }
        public Album(string name, string genre, List<string> allMaterials, List<string> _media, string description)
        {
            this.Name = name;
            Media= _media;
            this.Description = description;
            this.Genre = genre;
            this.AllMaterials = allMaterials;
            AlbumRepository.save(this);
        }
        
        
    }
}
