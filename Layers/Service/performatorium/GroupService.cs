using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class GroupService
    {
        public static Dictionary<string, Group> get10Popular()
        {
            Dictionary<string, Group> popular = new Dictionary<string, Group>();
            Dictionary<string, Group> all = GroupRepository.getAll();
            Dictionary<int, string> allRatings = new Dictionary<int, string>();
            foreach (KeyValuePair<string, Group> pair in all)
            {
                allRatings.Add(calculateRating(pair.Value), pair.Key);
            }
            List<string> sortedRatings = allRatings.OrderBy(x => x.Key).Select(x => x.Value).ToList<string>();
            for (int i = 0; i < 10; i++)
            {
                if (sortedRatings.Count < i) { break; }
                popular.Add(sortedRatings[i], all[sortedRatings[i]]);
            }
            return popular;

        }
        public static int calculateRating(Group group)
        {
            int rating = 0;
            
            int reviews = group.allComments.Count * 2 + group.allStarRatings.Count;
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
