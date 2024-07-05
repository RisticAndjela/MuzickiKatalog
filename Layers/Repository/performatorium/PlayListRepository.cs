using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class PlayListRepository
    {
        public static Dictionary<string,List<PlayList>> getAll()
        {
            return new Dao<PlayList>(GlobalVariables.playListsFile).ReadLargeDictionaryFromFile();
        }
        public static void save(PlayList playList)
        {
            SaveOneInstance<PlayList>.SaveOneInstanceInLargeDictionary(playList, playList.owner, GlobalVariables.playListsFile);
        }
        public static void saveChanges(PlayList playList)
        {
            if (getAll().ContainsKey(playList.owner)) { }
            Dao<PlayList> dao = new Dao<PlayList>(GlobalVariables.playListsFile);
            Dictionary<string, List<PlayList>> all = dao.ReadLargeDictionaryFromFile();
            foreach (PlayList item in all[playList.owner])
            {
                if (item.Name == playList.Name) { item.materials = playList.materials; break; }
            }
            dao.WriteLargeDictionaryToFile(all);
        }
        
    }
}
