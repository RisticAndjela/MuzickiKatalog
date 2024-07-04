using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Controller.performatorium
{
    public class PlayListController
    {
        //albums,materilas
        public static (Dictionary<string,Tuple<string,string>>, Dictionary<string, Tuple<string, string>>) getAllAlbumsAndMaterials(PlayList playlist)
        {
            Dictionary<string, Material> materials= new Dictionary<string, Material>();
            Dictionary<string, Album> albums = new Dictionary<string, Album>();
            foreach(string one in playlist.materials)
            {
                Material material = GetFromIDs<Material>.get(one, GlobalVariables.materialsFile).Item2;
                if (material != null)
                {
                    materials.Add(MakeIDs.makeMaterialID(material), material);
                }
                else
                {
                    Album album=GetFromIDs<Album>.get(one,GlobalVariables.albumsFile).Item2;
                    if(album != null)
                    {
                        albums.Add(MakeIDs.makeAlbumID(album), album); 
                    }
                }
            }
            return(AlbumController.getForList(albums), MaterialController.getForList(materials));
        }
    }
}
