using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Service.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class AlbumRepository
    {
        public static Dictionary<string, Album> getAll()
        {
            return new Dao<Album>(GlobalVariables.albumsFile).ReadDictionaryFromFile();
        }
        public static void save(Album album)
        {
            string id = MakeIDs.makeAlbumID(album);
            SaveOneInstance<Album>.SaveOneInstanceInDictionary(album, id, GlobalVariables.albumsFile);
            foreach (string s in album.AllMaterials)
            {
                (_, Material material) = GetFromIDs<Material>.get(s, GlobalVariables.materialsFile);
                MaterialService.PutInAlbum(material,id);
                foreach (string s2 in material.Contributors)
                {
                    (bool isArtist, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                    if (isArtist) { ArtistService.AddAlbumInfo(artist,album); }
                    else
                    {
                        (_, Group group) = GetFromIDs<Group>.get(s2, GlobalVariables.groupsFile);
                        GroupService.addAlbum(group,album);
                    }
                }
            }
        }
    }
}
