using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.contributors
{
    public class UserRepository
    {
        public static Dictionary<string, User> getAll()
        {
            return new Dao<User>(GlobalVariables.usersFile).ReadDictionaryFromFile();
        }

    }
}
