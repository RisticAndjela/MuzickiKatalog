using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.support;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class ArtistService : IArtistService
    {
        public static void AddGroupInfo(Artist artist, Group group)
        {
            artist.Groups.Add(MakeIDs.makeGroupID(group));
            ArtistRepository.save(artist);
        }
        public static void AddMaterialInfo(Artist artist, Material material)
        {
            artist.AllMaterials.Add(MakeIDs.makeMaterialID(material));
            ArtistRepository.save(artist);
        }
        public static void AddAlbumInfo(Artist artist, Album album)
        {
            artist.AllMaterials.Add(MakeIDs.makeAlbumID(album));
            ArtistRepository.save(artist);
        }
        public static void AddGenreInfo(Artist artist, Genre genre)
        {
            artist.Genres.Add(genre.Name);
            ArtistRepository.save(artist);
        }
        public static void LeaveComment(Artist artist, Comment comment)
        {
            artist.AllComments.Add(comment);
            ArtistRepository.save(artist);
        }
        public static void LeaveRating(Artist artist, StarRating rating)
        {
            artist.AllStarRatings.Add(rating);
            ArtistRepository.save(artist);
        }
        public static void Visited(Artist artist)
        {
            artist.Visits++;
            ArtistRepository.save(artist);
        }
        
       
    }
}
