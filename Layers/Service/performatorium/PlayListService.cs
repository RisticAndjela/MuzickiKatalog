using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Repository.performatorium;
using System.Xml.Linq;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class PlayListService
    {
        public static void addMaterialbyID(PlayList playlist, string material)
        {
            if (!playlist.materials.Any(m => m == material))
            {
                playlist.materials.Add(material);
            }
            PlayListRepository.save(playlist);
        }
        public static void addMaterial(PlayList playlist, Material material) {
            if (!playlist.materials.Any(m => m == MakeIDs.makeMaterialID(material)))
            {
                playlist.materials.Add(MakeIDs.makeMaterialID(material));
            }
            PlayListRepository.save(playlist);
        }
        public static void addMaterial( PlayList playlist, Album material) {
            if (!playlist.materials.Any(m => m == MakeIDs.makeAlbumID(material)))
            {
                playlist.materials.Add(MakeIDs.makeAlbumID(material));
            }
            PlayListRepository.save(playlist);
        }
        public static PlayList getPlayList(Member member, string name)
        {
            return PlayListRepository.getAll()[member.username].FirstOrDefault(a => a.Name == name);
        }

        public static void changeVisibility(PlayList playlist)
        {
            playlist.isPrivate=!playlist.isPrivate;
            PlayListRepository.save(playlist);
        }

        public static List<PlayList> getAllPlayLists(Member member)
        {
            return PlayListRepository.getAll()[member.username];

        }
    }
}
