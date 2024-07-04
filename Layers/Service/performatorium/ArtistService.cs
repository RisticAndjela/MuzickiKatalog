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
            string id = MakeIDs.makeGroupID(group);
            if(!artist.Groups.Contains(id)) artist.Groups.Add(id);
            ArtistRepository.save(artist);
        }
        public static void AddMaterialInfo(Artist artist, Material material)
        {
            string id = MakeIDs.makeMaterialID(material); 
            if (!artist.AllMaterials.Contains(id)) artist.AllMaterials.Add(id);
            ArtistRepository.save(artist);
        }
        public static void AddAlbumInfo(Artist artist, Album album)
        {
            string id = MakeIDs.makeAlbumID(album);
            if (!artist.AllMaterials.Contains(id)) artist.AllMaterials.Add(id);
            ArtistRepository.save(artist);
        }
        public static void AddGenreInfo(Artist artist, Genre genre)
        {
            string id = genre.Name;
            if(!artist.Genres.Contains(id))artist.Genres.Add(id);
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
