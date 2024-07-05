
namespace muzickiKatalog.Layers.dao
{
    public class SaveOneInstance<T>
    {
        //saves new or updated version of the instance in dictionary
        public static void SaveOneInstanceInDictionary(T instance,string id,string filename)
        {
            Dao<T> dao = new Dao<T>(filename);
            Dictionary<string, T> all = dao.ReadDictionaryFromFile();
            if (all.ContainsKey(id))
            {
                all[id]= instance;
            }
            else
            {
                all.Add(id, instance);
            }
            dao.WriteDictionaryToFile(all);
        }
        //saves new instance in list, if needs a change it will be required a drop before calling this one
        public static void SaveOneInstanceInList(T instance, string filename)
        {
            Dao<T> dao = new Dao<T>(filename);
            List<T> all = dao.ReadListFromFile();
            all.Add(instance);
            dao.WriteListToFile(all);
        }
        public static void SaveOneInstanceInLargeDictionary(T instance,string id, string filename)
        {
            Dao<T> dao = new Dao<T>(filename);
            Dictionary<string,List<T>> all = dao.ReadLargeDictionaryFromFile();
            if (all.ContainsKey(id)) {
                all[id].Add(instance);
            }
            else
            {
                all.Add(id, new List<T>() { instance});
            }
            dao.WriteLargeDictionaryToFile(all);
        }
    }
}
