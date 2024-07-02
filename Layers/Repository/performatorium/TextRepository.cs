using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;


namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class TextRepository
    {
        public static Dictionary<string, Text> getAll()
        {
            return new Dao<Text>(GlobalVariables.textsFile).ReadDictionaryFromFile();
        }
        public static void save(Text text,string id)
        {
            SaveOneInstance<Text>.SaveOneInstanceInDictionary(text, id, GlobalVariables.textsFile);
        }
    }
}
