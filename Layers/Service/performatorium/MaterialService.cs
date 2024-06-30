using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class MaterialService
    {
        public static Dictionary<string, Material> getPopular()
        {
            Dictionary<string, Material> popular = new Dictionary<string, Material>();
            Dictionary<string, Material> all = MaterialRepository.getAll();
            Dictionary<int, string> allRatings = new Dictionary<int, string>();
            foreach (KeyValuePair<string, Material> pair in all)
            {
                if (pair.Value.publishDate > DateOnly.FromDateTime(DateTime.Now).AddDays(-50))
                {
                    allRatings.Add(calculateRating(pair.Value), pair.Key);
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




        public static int calculateRating(Material material)
        {
            int rating = 0;
            switch (material.visits)
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

            int reviews = material.comments.Count * 2 + material.starRatings.Count;
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
