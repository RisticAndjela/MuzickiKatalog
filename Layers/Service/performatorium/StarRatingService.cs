using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.contributors.Interfaces;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.performatorium.Interfaces;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.Service.contributors;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class StarRatingService: IStarRatingService
    {
        public static void AddToNeedApproveList(StarRating star)
        {
            (bool have, Material material) = GetFromIDs<Material>.get(star.idOfPlaceholder, GlobalVariables.materialsFile);
            if (have)
            {
                GetFromIDs<Editor>.get(material.Editor, GlobalVariables.editorsFile).Item2.addRating(star);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(star.idOfPlaceholder, GlobalVariables.artistsFile);
            if ((have))
            {
                GetFromIDs<Editor>.get(artist.Editor, GlobalVariables.editorsFile).Item2.addRating(star);
            }
            (have, Group group) = GetFromIDs<Group>.get(star.idOfPlaceholder, GlobalVariables.groupsFile);
            if (have)
            {
                (_, Artist artistOfGroup) = GetFromIDs<Artist>.get(group.Artists[0], GlobalVariables.artistsFile);
                GetFromIDs<Editor>.get(artistOfGroup.Editor, GlobalVariables.editorsFile).Item2.addRating(star);
            }
            (have, Album album) = GetFromIDs<Album>.get(star.idOfPlaceholder, GlobalVariables.groupsFile);
            if (have)
            {
                (_, Material materialInAlbum) = GetFromIDs<Material>.get(album.AllMaterials[0], GlobalVariables.materialsFile);
                (_, Artist artistInAlbum) = GetFromIDs<Artist>.get(materialInAlbum.Editor, GlobalVariables.artistsFile);
                GetFromIDs<Editor>.get(artistInAlbum.Editor, GlobalVariables.editorsFile).Item2.addRating(star);
            }
        }
        public static void Approved(StarRating star)
        {
            (bool have, Member member) = GetFromIDs<Member>.get(star.reviewer, GlobalVariables.membersFile);
            if (have)
            {
                MemberService.LeaveRating(member,star);
            }
            (have, Material material) = GetFromIDs<Material>.get(star.idOfPlaceholder, GlobalVariables.materialsFile);
            if (have)
            {
                MaterialService.LeaveRating(material, star);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(star.idOfPlaceholder, GlobalVariables.artistsFile);
            if ((have))
            {
                ArtistService.LeaveRating(artist, star);
            }

        }

        public static IEnumerable<(string PlaceholderId, IEnumerable<StarRating> Ratings)> GetRatingsByPlaceholder()
        {
            var starRatingsSupplier = StarRatingRepository.GetAll;

            return from starRating in starRatingsSupplier()
                   group starRating by starRating.idOfPlaceholder into placeholderRatings
                   select (placeholderRatings.Key, placeholderRatings.AsEnumerable());
        }


        
        public static IEnumerable<(IMaterial Material, IEnumerable<StarRating> Ratings)> GetRatingsByMaterial()
        {
            var getMaterialById = (string id) => GetFromIDs<Material>.get(id, GlobalVariables.materialsFile).Item2;

            foreach (var (placeholderId, ratings) in GetRatingsByPlaceholder())
            {
                // if it is a rating for a material
                if (getMaterialById(placeholderId) is var material && material != null)
                {
                    yield return (material, ratings);
                }
            }
        }
    }
}
