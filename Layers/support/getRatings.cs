using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Repository.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.support
{
    public class getRatings<T> where T: class, IAdditional
    {
        public static Dictionary<string, T> Get10Popular(Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            Dictionary<string, T> popular = new Dictionary<string, T>();
            Dictionary<string, T> all = GetAll(allMaterials,allAlbums,allArtists,allGroups);
            Dictionary<int, List<string>> allRatings = new Dictionary<int, List<string>>();

            foreach (KeyValuePair<string, T> pair in all)
            {
                int rating = CalculateRating(pair.Value);
                if (!allRatings.ContainsKey(rating))
                {
                    allRatings[rating] = new List<string>();
                }
                allRatings[rating].Add(pair.Key);
            }

            List<string> sortedRatings = allRatings
                .OrderByDescending(x => x.Key)
                .SelectMany(x => x.Value)
                .ToList();

            for (int i = 0; i < 10; i++)
            {
                if (sortedRatings.Count <= i) { break; }
                popular.Add(sortedRatings[i], all[sortedRatings[i]]);
            }

            return popular;


        }
        public static Dictionary<string, T> GetAll(Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            Dictionary<string, T> all = new Dictionary<string, T>();

            if (typeof(T) == typeof(Material))
            {
                foreach (var item in allMaterials)
                {
                    all.Add(item.Key, item.Value as T);
                }
            }
            else if (typeof(T) == typeof(Artist))
            {
                foreach (var item in allArtists)
                {
                    all.Add(item.Key, item.Value as T);
                }
            }
            else if (typeof(T) == typeof(Album))
            {
                foreach (var item in allAlbums)
                {
                    all.Add(item.Key, item.Value as T);
                }
            }
            else if (typeof(T) == typeof(Group))
            {
                foreach (var item in allGroups)
                {
                    all.Add(item.Key, item.Value as T);
                }
            }

            return all;
        }

        public static int CalculateRating(T material)
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
