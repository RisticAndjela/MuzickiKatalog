using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.support;
using System.Windows.Media.Media3D;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class AlbumService : IAlbumService
    {
        public static void AddComment(Album album,Comment comment)
        {
            album.AllComments.Add(comment);
            AlbumRepository.save(album);
        }
        public static void AddRating(Album album, StarRating stars)
        {
            album.AllStarRatings.Add(stars);
            AlbumRepository.save(album);
        }
        public static void Visited(Album album)
        {
            album.Visits++;
            AlbumRepository.save(album);
        }


    }
}
