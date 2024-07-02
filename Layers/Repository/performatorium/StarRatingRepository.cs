using muzickiKatalog.Layers.Model.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class StarRatingRepository
    {
        public static List<StarRating> getAll()
        {
            List<StarRating> final = new List<StarRating>();
            Dictionary<string, Artist> artists = ArtistRepository.getAll();
            foreach (Artist artist in artists.Values)
            {
                final.AddRange(artist.AllStarRatings);
            }
            Dictionary<string, Group> groups = GroupRepository.getAll();
            foreach (Group group in groups.Values)
            {
                final.AddRange(group.AllStarRatings);
            }
            Dictionary<string, Material> mateials = MaterialRepository.getAll();
            foreach (Material material in mateials.Values)
            {
                final.AddRange(material.AllStarRatings);
            }
            Dictionary<string, Album> albums = AlbumRepository.getAll();
            foreach (Album album in albums.Values)
            {
                final.AddRange(album.AllStarRatings);
            }

            return final;
        }
    }
}
