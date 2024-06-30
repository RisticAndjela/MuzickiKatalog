using muzickiKatalog.Layers.Model.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.support.IDparser
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
            id.Append($"{group.name}:");
            foreach (String s in group.artists)
            {
                (_,Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                id.Append(artist.lastName);
                id.Append("-");
            }
            return id.ToString();
        }
        public static string makeAlbumID(Album album)
        {
            StringBuilder id = new StringBuilder();
            id.Append($"{album.name}:");
            foreach (String s in album.allMaterials)
            {
                id.Append(s);
                id.Append("-");
            }
            return id.ToString();
        }
        public static string makeMaterialID(Material material)
        {
           StringBuilder id = new StringBuilder();
            id.Append($"{material.title}:");
            foreach (String s in material.contributors)
            {
                (bool isArtist, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                if (isArtist)
                {
                    id.Append(artist.lastName);
                    id.Append("-");
                }
                else
                {
                    (_, Group group) = GetFromIDs<Group>.get(s, GlobalVariables.groupsFile);
                    id.Append(group.name);
                }
            }
            return id.ToString();
        }
    }
}
