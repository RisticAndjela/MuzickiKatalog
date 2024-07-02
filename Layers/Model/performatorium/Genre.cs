using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;


namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Genre : IDocumentation
    {
        public string Name { get; set; }
        public List<string> AllMaterials { get; set; }=new List<string>();
        public List<string> Media { get; set; }=new List<string>();
        public List<StarRating> AllStarRatings { get; set; }=new List<StarRating>();
        public List<Comment> AllComments { get; set; }=new List<Comment>();
        public int Visits { get; set; } = 0;


        public Genre() { }
        public Genre(string _name)
        {
            Name = _name;
            GenreRepository.save(this);
        }

    }
}
