using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.dao;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class MaterialRepository
    {
        public static Dictionary<string,Material> getAll()
        {
            return new Dao<Material>(GlobalVariables.materialsFile).ReadDictionaryFromFile();
        }
        
    }
}
