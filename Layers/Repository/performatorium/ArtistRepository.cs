using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class ArtistRepository
    {
        public static Dictionary<string,Artist> getAll()
        {
            return new Dao<Artist>(GlobalVariables.artistsFile).ReadDictionaryFromFile();
        }
        public static void save(Artist artist)
        {
            SaveOneInstance<Artist>.SaveOneInstanceInDictionary(artist, MakeIDs.makeArtistID(artist), GlobalVariables.artistsFile);
        }
    }
}
