using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.contributors
{
    public class AdminRepository
    {
        public static Dictionary<string, Admin> getAll()
        {
            return new Dao<Admin>(GlobalVariables.adminFile).ReadDictionaryFromFile();
        }
    }
}
