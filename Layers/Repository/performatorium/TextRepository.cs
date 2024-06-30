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
    }
}
