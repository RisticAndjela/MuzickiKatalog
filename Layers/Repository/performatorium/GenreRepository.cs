using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class GenreRepository
    {
        public static Dictionary<string, Genre> getAll()
        {
            return new Dao<Genre>(GlobalVariables.genresFile).ReadDictionaryFromFile();
        }
        public static void save(Genre genre)
        {
            SaveOneInstance<Genre>.SaveOneInstanceInList(genre, GlobalVariables.genresFile);
        }
        public static List<string> getAllNames()
        {
            Dictionary<string, Genre> all = getAll();
            List<string > names = new List<string>();
            foreach (Genre genre in all.Values) { names.Add(genre.Name); }
            return names;
        }
    }
}
