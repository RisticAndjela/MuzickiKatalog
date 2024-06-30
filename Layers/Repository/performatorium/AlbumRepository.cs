using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class AlbumRepository
    {
        public static Dictionary<string, Album> getAll()
        {
            return new Dao<Album>(GlobalVariables.albumsFile).ReadDictionaryFromFile();
        }
    }
}
