using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.contributors
{
    public class EditorRepository
    {
        public static Dictionary<string, Editor> getAll()
        {
            return new Dao<Editor>(GlobalVariables.editorsFile).ReadDictionaryFromFile();
        }
    }
}
