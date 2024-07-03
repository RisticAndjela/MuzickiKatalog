using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.performatorium
{
    public class CommentRepository
    {
        public static List<Comment> getAll( Dictionary<string, Material> allMaterials,Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            List<Comment> final = new List<Comment>();
            foreach (Artist artist in allArtists.Values)
            {
                final.AddRange(artist.AllComments);
            }
            foreach (Group group in allGroups.Values) {
                final.AddRange(group.AllComments);
            }
            foreach(Material material in allMaterials.Values)
            {
                final.AddRange(material.AllComments);
            }
            foreach (Album album in allAlbums.Values)
            {
                final.AddRange(album.AllComments);
            }

            return final;
        }
    }
}
