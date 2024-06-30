using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Artist : Person
    {
        public string editor {  get; set; }
        public artistType type { get; set; }
        public List<string> genres { get; set; } = new List<string>();
        public List<string> groups { get; set; } = new List<string>();
        public List<string> materials { get; set; } = new List<string>();
        public List<string> media { get; set; } = new List<string>();
        public List<Comment> biographyComments { get; set; }= new List<Comment>();
        public List<StarRating> biographyStarRatings { get; set; }= new List<StarRating>();
        public Artist() { }
        public Artist(string _editor,string _name, string _lastName, Gender _gender, DateOnly _birthday, string _biography, artistType _type,List<string> _genres, List<string> _media) : base("", "",_name, _lastName, _gender, _birthday, personType.artist)
        {
            editor = _editor;
            type=_type;
            media = _media;
            genres = _genres;
            type = _type;
            new Text(_biography, MakeIDs.makeArtistID(this));
            save();
        }
        public void save()
        {
            SaveOneInstance<Artist>.SaveOneInstanceInDictionary(this, MakeIDs.makeArtistID(this), GlobalVariables.artistsFile);
        }
        public void addGroupInfo(Group group)
        {
            groups.Add(MakeIDs.makeGroupID(group));
            save();
        }
        public void addMaterialInfo(Material material)
        {
            materials.Add(MakeIDs.makeMaterialID(material));
            save();
        }
        public void addAlbumInfo(Album album)
        {
            materials.Add(MakeIDs.makeAlbumID(album));
            save();
        }
        public void addGenreInfo(Genre genre)
        {
            genres.Add(genre.name);
            save();
        }
        public void LeaveComment(Comment comment)
        {
            biographyComments.Add(comment);
            save();
        }
        public void LeaveRating(StarRating rating)
        {
            biographyStarRatings.Add(rating);
            save();
        }
    }
}
