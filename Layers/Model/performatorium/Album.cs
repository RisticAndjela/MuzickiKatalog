using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Album
    {
        public string name { get; set; }
        public string description { get; set; }
        public string genre { get; set; }
        public List<string> allMaterials { get; set; }=new List<string>();
        public List<string> media { get; set; }=new List<string>();
        public List<Comment> allComments { get; set; } = new List<Comment>();
        public List<StarRating> allStarRatings { get; set; } = new List<StarRating>();

        public Album() { }
        public Album(string name, string genre, List<string> allMaterials, List<string> _media, string description)
        {
            this.name = name;
            media= _media;
            this.description = description;
            this.genre = genre;
            this.allMaterials = allMaterials;
            save();
        }
        public void save()
        {
            string id = MakeIDs.makeAlbumID(this);
            SaveOneInstance<Album>.SaveOneInstanceInDictionary(this,id , GlobalVariables.albumsFile);
            foreach (string s in allMaterials)
            {
                (_, Material material) = GetFromIDs<Material>.get(s, GlobalVariables.materialsFile);
                material.inAlbum(id);
                foreach(string s2 in material.contributors)
                {
                    (bool isArtist, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                    if (isArtist) { artist.addAlbumInfo(this); }
                    else {
                        (_, Group group) = GetFromIDs<Group>.get(s2, GlobalVariables.groupsFile);
                        group.addAlbum(this);
                    }
                }
            }
        }
        public void addComment(Comment comment)
        {
            allComments.Add(comment);
            save();
        }
        public void addRating(StarRating stars)
        {
            allStarRatings.Add(stars);
            save();
        }
    }
}
