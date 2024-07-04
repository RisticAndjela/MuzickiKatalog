using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class GenreController
    {
        public static Dictionary<string, Tuple<string, string>> MaterialsByGenres(Genre genre, Dictionary<string,Material> allMaterials)
        {
            Dictionary<string, Material> final = new Dictionary<string,Material>();
            foreach (KeyValuePair<string, Material> pair in allMaterials)
            {
                if (pair.Value.Genres.Contains(genre.Name))
                {
                    final.Add(pair.Key, pair.Value);
                }
            }
            return MaterialController.getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> AlbumsByGenres(Genre genre, Dictionary<string,Album> allAlbums, Dictionary<string,Material> allMaterials)
        {
            Dictionary<string, Album> final = new Dictionary<string,Album>();
            foreach (KeyValuePair<string, Album> pair in allAlbums)
            {
                List<string> Genres=new List<string>();
                foreach(string materialString in pair.Value.AllMaterials)
                {
                    Genres.AddRange(allMaterials[materialString].Genres);
                }
                if (Genres.Contains(genre.Name))
                {
                    final.Add(pair.Key, pair.Value);
                }
            }
            return AlbumController.getForList(final);
        }
        public static Dictionary<string, Tuple<string, string>> ArtistsByGenres(Genre genre, Dictionary<string,Artist> allArtists)
        {
            Dictionary<string, Artist> final = new Dictionary<string,Artist>();
            foreach (KeyValuePair<string, Artist> pair in allArtists)
            {
                if (pair.Value.Genres.Contains(genre.Name))
                {
                    final.Add(pair.Key, pair.Value);
                }
            }
            return ArtistController.getForList(final);
        }

        public static Dictionary<string, Tuple<string, string>> GroupsByGenres(Genre genre, Dictionary<string, Group> allGroups, Dictionary<string, Artist> allArtists)
        {
            Dictionary<string, Group> final = new Dictionary<string, Group>();
            foreach (KeyValuePair<string, Group> pair in allGroups)
            {
                List<string> Genres = new List<string>();
                foreach (string artistString in pair.Value.Artists)
                {
                    Genres.AddRange(allArtists[artistString].Genres);
                }
                if (Genres.Contains(genre.Name))
                {
                    final.Add(pair.Key, pair.Value);
                }
            }
            return GroupController.getForList(final);
        }
    }
}
