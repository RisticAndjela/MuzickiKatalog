using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Model.dao;
using muzickiKatalog.Model.Domain.contributors;
using muzickiKatalog.Model.Domain.performatorium;

namespace muzickiKatalog.Model.support.IDparser
{
    public interface GetFromIDs<T>
    {
        public static (bool, T) get(string id,string filename)
        {
            Dictionary<string, T> iteams = new Dao<T>(filename).ReadDictionaryFromFile();
            if (iteams.ContainsKey(id))
            {
                return (true, iteams[id]);
            }
            return (false, default(T));
        }
       
    }
}
