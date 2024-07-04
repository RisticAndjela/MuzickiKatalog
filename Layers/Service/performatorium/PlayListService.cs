using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Repository.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class PlayListService
    {
        public static void addMaterial(Member member, PlayList playlist, Material material) {
            playlist.materials.Add(MakeIDs.makeMaterialID(material));
            PlayListRepository.save(playlist, member.username);
        }
        public static void addMaterial(Member member, PlayList playlist, Album material) {
            playlist.materials.Add(MakeIDs.makeAlbumID(material));
            PlayListRepository.save(playlist, member.username);
        }
        public static PlayList getPlayList(Member member, string name)
        {
            return PlayListRepository.getAll()[member.username].FirstOrDefault(a => a.Name == name);
        }

    }
}
