using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class MaterialService: IMaterialService
    {

        public static void LeaveRating(Material material,StarRating rating)
        {
            material.AllStarRatings.Add(rating);
            MaterialRepository.save(material);
        }

        public static void LeaveComment(Material material, Comment comment)
        {
            material.AllComments.Add(comment);
            MaterialRepository.save(material);
        }
        public static void Visited(Material material)
        {
            material.Visits++;
            MaterialRepository.save(material);
        }
        public static void PutInAlbum(Material material, string _album)
        {
            material.Albums = _album;
            MaterialRepository.save(material);
        }

        public static string getDescription(Material material)
        {
            string id= MakeIDs.makeMaterialID(material);
            return TextService.getTextByID(id).text;
        }
    }
}
