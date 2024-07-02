using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class GenreService:IGenreService
    {
        public static void AddMaterial(Genre genre, Material material)
        {
            if (genre != null)
            {
                genre.AllMaterials.Add(MakeIDs.makeMaterialID(material));
                GenreRepository.save(genre);
            }
        }
        public static void AddAlbum(Genre genre, Album album)
        {
            if (genre != null)
            {
                genre.AllMaterials.Add(MakeIDs.makeAlbumID(album));
                GenreRepository.save(genre);
            }
        }
        public static void AddComment(Genre genre, Comment comment)
        {
            genre.AllComments.Add(comment);
            GenreRepository.save(genre);
        }
        public static void AddRating(Genre genre, StarRating stars)
        {
            genre.AllStarRatings.Add(stars);
            GenreRepository.save(genre);
        }

    }
}
