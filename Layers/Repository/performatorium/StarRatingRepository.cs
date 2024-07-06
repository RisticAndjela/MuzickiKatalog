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
        public static List<StarRating> getAll(Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            List<StarRating> final = new List<StarRating>();
            foreach (Artist artist in allArtists.Values)
            {
                final.AddRange(artist.AllStarRatings);
            }
            foreach (Group group in allGroups.Values)
            {
                final.AddRange(group.AllStarRatings);
            }
            foreach (Material material in allMaterials.Values)
            {
                final.AddRange(material.AllStarRatings);
            }
            foreach (Album album in allAlbums.Values)
            {
                final.AddRange(album.AllStarRatings);
            }

            return final;
        }

        public static IEnumerable<StarRating> GetAll()
        {
            return getAll(MaterialRepository.getAll(), AlbumRepository.getAll(), ArtistRepository.getAll(), GroupRepository.getAll());
        }
    }
}
