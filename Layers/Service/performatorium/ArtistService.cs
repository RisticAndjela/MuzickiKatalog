using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class ArtistService : IArtistService
    {
        public static void AddGroupInfo(Artist artist, Group group)
        {
            artist.Groups.Add(MakeIDs.makeGroupID(group));
            ArtistRepository.save(artist);
        }
        public static void AddMaterialInfo(Artist artist, Material material)
        {
            artist.AllMaterials.Add(MakeIDs.makeMaterialID(material));
            ArtistRepository.save(artist);
        }
        public static void AddAlbumInfo(Artist artist, Album album)
        {
            artist.AllMaterials.Add(MakeIDs.makeAlbumID(album));
            ArtistRepository.save(artist);
        }
        public static void AddGenreInfo(Artist artist, Genre genre)
        {
            artist.Genres.Add(genre.Name);
            ArtistRepository.save(artist);
        }
        public static void LeaveComment(Artist artist, Comment comment)
        {
            artist.AllComments.Add(comment);
            ArtistRepository.save(artist);
        }
        public static void LeaveRating(Artist artist, StarRating rating)
        {
            artist.AllStarRatings.Add(rating);
            ArtistRepository.save(artist);
        }
        public static void Visited(Artist artist)
        {
            artist.Visits++;
            ArtistRepository.save(artist);
        }
        public static Dictionary<string, Artist> Get10Popular()
        {
            Dictionary<string, Artist> popular = new Dictionary<string, Artist>();
            Dictionary<string, Artist> all = ArtistRepository.getAll();
            Dictionary<int, string> allRatings = new Dictionary<int, string>();
            foreach (KeyValuePair<string, Artist> pair in all)
            {
                allRatings.Add(CalculateRating(pair.Value), pair.Key);
            }
            List<string> sortedRatings = allRatings.OrderBy(x => x.Key).Select(x => x.Value).ToList<string>();
            for (int i = 0; i < 10; i++)
            {
                if (sortedRatings.Count < i) { break; }
                popular.Add(sortedRatings[i], all[sortedRatings[i]]);
            }
            return popular;

        }
        public static int CalculateRating(Artist artist)
        {
            int rating = 0;

            int reviews = artist.AllComments.Count * 2 + artist.AllStarRatings.Count;
            switch (reviews)
            {
                case < 10:
                    rating += 5;
                    break;
                case < 20:
                    rating += 10;
                    break;
                case < 40:
                    rating += 35;
                    break;
                case < 50:
                    rating += 60;
                    break;
            }
            return rating;
        }
    }
}
