using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class GroupRepository
    {
        public static Dictionary<string, Group> getAll()
        {
            return new Dao<Group>(GlobalVariables.groupsFile).ReadDictionaryFromFile();
        }
        public static void save(Group group)
        {
            SaveOneInstance<Group>.SaveOneInstanceInDictionary(group, MakeIDs.makeGroupID(group), GlobalVariables.groupsFile);
            foreach (string s in group.Artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                ArtistService.AddGroupInfo(artist, group);
            }
        }
    }
}
