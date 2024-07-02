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
            return $"{artist.Name}_{artist.LastName}_{artist.Birthday.ToString()}";
        }
        public static string makeGroupID(Group group)
        {
            StringBuilder id = new StringBuilder();
            id.Append($"{group.Name}:");
            foreach (String s in group.Artists)
            {
                (_,Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                id.Append(artist.LastName);
                id.Append("-");
            }
            return id.ToString();
        }
        public static string makeAlbumID(Album album)
        {
            StringBuilder id = new StringBuilder();
            id.Append($"{album.Name}:");
            foreach (String s in album.AllMaterials)
            {
                id.Append(s);
                id.Append("-");
            }
            return id.ToString();
        }
        public static string makeMaterialID(Material material)
        {
           StringBuilder id = new StringBuilder();
            id.Append($"{material.Title}:");
            foreach (String s in material.Contributors)
            {
                (bool isArtist, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                if (isArtist)
                {
                    id.Append(artist.LastName);
                    id.Append("-");
                }
                else
                {
                    (_, Group group) = GetFromIDs<Group>.get(s, GlobalVariables.groupsFile);
                    id.Append(group.Name);
                }
            }
            return id.ToString();
        }
    }
}
