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
        public static List<Comment> getAll()
        {
            List<Comment> final = new List<Comment>();
            Dictionary<string, Artist> artists=ArtistRepository.getAll();
            foreach (Artist artist in artists.Values)
            {
                final.AddRange(artist.biographyComments);
            }
            Dictionary<string,Group>  groups=GroupRepository.getAll();
            foreach (Group group in groups.Values) {
                final.AddRange(group.allComments);
            }
            Dictionary<string, Material> mateials=MaterialRepository.getAll();
            foreach(Material material in mateials.Values)
            {
                final.AddRange(material.comments);
            }
            Dictionary<string, Album> albums=AlbumRepository.getAll();
            foreach (Album album in albums.Values)
            {
                final.AddRange(album.allComments);
            }

            return final;
        }
    }
}
