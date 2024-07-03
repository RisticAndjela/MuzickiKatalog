using muzickiKatalog.Layers.Model.performatorium;
using materialNS=muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class ArtistController
    {
        public static Dictionary<string, Artist> Get10Popular(Dictionary<string, materialNS.Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            return getRatings<Artist>.Get10Popular(allMaterials,allAlbums,allArtists,allGroups);

        }
        public static Dictionary<string, Tuple<string, string>> getForList(Dictionary<string, Artist> artists_)
        {
            Dictionary<string, Tuple<string, string>> allArtists = new Dictionary<string, Tuple<string, string>>();
            foreach (KeyValuePair<string, Artist> pair in artists_)
            {
                allArtists.Add(pair.Key, new Tuple<string, string>($"{pair.Value.Name} {pair.Value.LastName}", pair.Value.Media[0]));
            }
            return allArtists;
        }
        
        public static Dictionary<string, Tuple<string, string>> FindArtistsWithSameGenre(Artist thisArtist, Dictionary<string, Artist> allArtists)
        {
            Dictionary<string, Artist> final = new Dictionary<string, Artist>();

            foreach (KeyValuePair<string, Artist> pair in allArtists)
            {
                if (pair.Value.Equals(thisArtist)) { continue; }
                foreach (string genre in thisArtist.Genres) { 
                    if (pair.Value.Genres.Contains(genre)) { final.Add(pair.Key, pair.Value);break; }
                }
            }
            return getForList(final);
        }
    }
}
