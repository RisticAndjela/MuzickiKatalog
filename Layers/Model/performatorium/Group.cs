using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Group
    {
        public string name {  get; set; }
        public DateOnly started {  get; set; }
        public bool active {  get; set; }
        public List<string> artists { get; set; } = new List<string>();
        public List<string> allMaterials { get; set; }= new List<string>();
        public List<string> media { get; set; }= new List<string>();
        public List<Comment> allComments {  get; set; }=new List<Comment>();
        public List<StarRating> allStarRatings { get; set; } = new List<StarRating>();

        public Group() { }
        public Group(string _name,DateOnly _started, bool _active,List<string> _artists, List<string> _media, string description)
        {
            artists = _artists;
            media = _media;
            name=_name;
            started=_started;
            active=_active;
            new Text(description, MakeIDs.makeGroupID(this));
            save();
        }
        public void save()
        {
            SaveOneInstance<Group>.SaveOneInstanceInDictionary(this, MakeIDs.makeGroupID(this), GlobalVariables.groupsFile);
            foreach (string s in artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                artist.addGroupInfo(this);
            }
        }

        public void addMaterial(Material material)
        {
            allMaterials.Add(MakeIDs.makeMaterialID(material));
            save();
            foreach(string s in artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                artist.addMaterialInfo(material);
            }
        }
        public void addAlbum(Album album)
        {
            allMaterials.Add(MakeIDs.makeAlbumID(album));
            save();
            foreach (string s in artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                artist.addAlbumInfo(album);
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
