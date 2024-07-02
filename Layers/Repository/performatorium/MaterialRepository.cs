using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class MaterialRepository
    {
        public static Dictionary<string,Material> getAll()
        {
            return new Dao<Material>(GlobalVariables.materialsFile).ReadDictionaryFromFile();
        }
        public static void save(Material material)
        {
            SaveOneInstance<Material>.SaveOneInstanceInDictionary(material, MakeIDs.makeMaterialID(material), GlobalVariables.materialsFile);
            foreach (string contributor in material.Contributors)
            {
                (bool have, Artist artist) = GetFromIDs<Artist>.get(contributor, GlobalVariables.artistsFile);
                if (have)
                {
                    ArtistService.AddMaterialInfo(artist, material);
                }
            }
        }
    }
}
