using muzickiKatalog.Layers.Model.performatorium;
using materialNS=muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class MaterialService: IMaterialService
    {

        public static void LeaveRating(materialNS.Material material,StarRating rating)
        {
            material.AllStarRatings.Add(rating);
            MaterialRepository.save(material);
        }

        public static void LeaveComment(materialNS.Material material, Comment comment)
        {
            material.AllComments.Add(comment);
            MaterialRepository.save(material);
        }
        public static void Visited(materialNS.Material material)
        {
            material.Visits++;
            MaterialRepository.save(material);
        }
        public static void PutInAlbum(materialNS.Material material, string _album)
        {
            material.Albums = _album;
            MaterialRepository.save(material);
        }
        public static Dictionary<string, materialNS.Material> Get10Popular()
        {
            Dictionary<string, materialNS.Material> popular = new Dictionary<string, materialNS.Material>();
            Dictionary<string, materialNS.Material> all = MaterialRepository.getAll();
            Dictionary<int, string> allRatings = new Dictionary<int, string>();
            foreach (KeyValuePair<string, materialNS.Material> pair in all)
            {
                if (pair.Value.PublishDate > DateOnly.FromDateTime(DateTime.Now).AddDays(-50))
                {
                    allRatings.Add(CalculateRating(pair.Value), pair.Key);
                }
            }
            List<string> sortedRatings = allRatings.OrderBy(x => x.Key).Select(x => x.Value).ToList<string>();
            for (int i = 0; i < 10; i++)
            {
                if (sortedRatings.Count < i) { break; }
                popular.Add(sortedRatings[i], all[sortedRatings[i]]);
            }
            return popular;

        }


        public static int CalculateRating(materialNS.Material material)
        {
            int rating = 0;
            switch (material.Visits)
            {
                case < 20:
                    rating += 1;
                    break;
                case < 50:
                    rating += 2;
                    break;
                case < 150:
                    rating += 5;
                    break;
                case < 400:
                    rating += 10;
                    break;
            }

            int reviews = material.AllComments.Count * 2 + material.AllStarRatings.Count;
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
