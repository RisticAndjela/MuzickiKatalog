using muzickiKatalog.Model.Domain.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Model.support.IDparser
{
    public class MakeIDs
    {
        public static string makeArtistID(Artist artist)
        {
            return $"{artist.name}_{artist.lastName}_{artist.birthday.ToString()}";
        }
        public static string makeGroupID(Group group)
        {
            StringBuilder id = new StringBuilder();
            foreach (Artist artist in group.artists)
            {
                id.Append(artist.name);
                id.Append("_");
                id.Append(artist.lastName);
                id.Append("-");
            }
            return id.ToString();
        }
        public static string makeMaterialID(Material material)
        {
            return $"-";
        }
    }
}
