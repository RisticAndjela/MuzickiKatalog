using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Material
    {
        public string editor {  get; set; }
        public string title {  get; set; }
        public DateOnly publishDate { get; set; }
        public DateOnly performedDate { get; set; }
        public string genre {  get; set; }
        public List<string> contributors {  get; set; }= new List<string>(); //ids of artists
        public List<string> media {  get; set; }= new List<string>(); 
        public List<Comment> comments { get; set; } = new List<Comment>();
        public List<StarRating> starRatings { get; set; } = new List<StarRating>();
        public int visits {  get; set; } = 0;
        public string album { get; set; } = null;
        public Material() { }

        public Material(string _editor,string _title,string _genre, DateOnly _publishDate, DateOnly _performedDate, List<string> _contributors, List<string> _media, string _description)
        {
            editor = _editor;
            title = _title;
            genre = _genre;
            media = _media;
            publishDate = _publishDate;
            performedDate = _performedDate;
            contributors = _contributors;
            new Text(_description, MakeIDs.makeMaterialID(this));
            save();
        }

        public void save()
        {
            SaveOneInstance<Material>.SaveOneInstanceInDictionary(this, MakeIDs.makeMaterialID(this), GlobalVariables.materialsFile);
            foreach(string contributor in contributors)
            {
                (bool have,Artist artist) = GetFromIDs<Artist>.get(contributor,GlobalVariables.artistsFile);
                if (have)
                {
                    artist.addMaterialInfo(this);
                }
            }
        }
        public void leaveRating(StarRating rating)
        {
            starRatings.Add(rating);
            save();
        }
        
        public void leaveComment(Comment comment)
        {
            comments.Add(comment);
            save();
        }
       public void visited()
        {
            visits++;
            save();
        }
        public void inAlbum(string _album) { album = _album; save(); }
    }
}
