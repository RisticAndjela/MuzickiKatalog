using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class AlbumController
    {
        public static Dictionary<string, Album> Get10Popular()
        {
            return getRatings<Album>.Get10Popular();
        }
        
        public static Dictionary<string, Tuple<string, string>> FindAlbumsFromSameArtist(Album thisAlbum, Dictionary<string, Album> allAlbums)
        {
            Dictionary<string, Artist> allArtists = ArtistRepository.getAll();
            Dictionary<string, Material> allMaterials = MaterialRepository.getAll();

            List<Artist> artists = new List<Artist>();

            foreach (string materialString in thisAlbum.AllMaterials) { 
                foreach(string artistString in allMaterials[materialString].Contributors)
                {
                    if (allArtists.ContainsKey(artistString))
                    {
                        artists.Add(allArtists[artistString]);
                    }
                }
            }

            Dictionary<string, Album> final = new Dictionary<string, Album>();

            foreach (KeyValuePair<string, Album> pair in allAlbums)
            {
                if(thisAlbum.Equals(pair.Value)) { continue;}
                foreach(string materialString in pair.Value.AllMaterials)
                {
                    Material material = allMaterials[materialString];
                    if (material.Albums.Equals(MakeIDs.makeAlbumID(thisAlbum))){ continue;}
                    foreach(string artistString in material.Contributors)
                    {
                        if (artists.Contains(allArtists[artistString])){final.Add(pair.Key, pair.Value); }
                    }
                }
            }
            return getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> FindAlbumsWithSameGenre(Album thisAlbum, Dictionary<string, Album> allAlbums)
        {
            Dictionary<string, Album> final =new Dictionary<string, Album>();

            foreach (KeyValuePair<string, Album> pair in allAlbums)
            {
                if (thisAlbum.Equals(pair.Value)) { continue; }
                if (thisAlbum.Genre.Equals(pair.Value.Genre)) { final.Add(pair.Key, pair.Value); }
            }
            return getForList(final) ;
        }
        public static Dictionary<string, Tuple<string, string>> getForList(Dictionary<string, Album> albums_)
        {
            Dictionary<string, Tuple<string, string>> allAlbums = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string, Album> pair in albums_)
            {
                allAlbums.Add(pair.Key, new Tuple<string, string>(pair.Value.Name, pair.Value.Media[0]));
            }
            return allAlbums;
        }
    }
}
