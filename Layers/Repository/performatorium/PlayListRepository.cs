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
    }
}
