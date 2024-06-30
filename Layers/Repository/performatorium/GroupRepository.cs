using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
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
    }
}
