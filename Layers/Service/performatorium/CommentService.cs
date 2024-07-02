using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class CommentService: ICommentService
    {
        public static void AddToNeedApproveList(Comment comment)
        {
            (bool have, Material material) = GetFromIDs<Material>.get(comment.idOfPlaceholder, GlobalVariables.materialsFile);
            if (have)
            {
                GetFromIDs<Editor>.get(material.Editor, GlobalVariables.editorsFile).Item2.addComment(comment);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(comment.idOfPlaceholder, GlobalVariables.artistsFile);
            if ((have))
            {
                GetFromIDs<Editor>.get(artist.Editor, GlobalVariables.editorsFile).Item2.addComment(comment);
            }
            (have, Group group) = GetFromIDs<Group>.get(comment.idOfPlaceholder, GlobalVariables.groupsFile);
            if (have)
            {
                (_, Artist artistOfGroup) = GetFromIDs<Artist>.get(group.Artists[0], GlobalVariables.artistsFile);
                GetFromIDs<Editor>.get(artistOfGroup.Editor, GlobalVariables.editorsFile).Item2.addComment(comment);
            }
            (have, Album album) = GetFromIDs<Album>.get(comment.idOfPlaceholder, GlobalVariables.groupsFile);
            if (have)
            {
                (_, Material materialInAlbum) = GetFromIDs<Material>.get(album.AllMaterials[0], GlobalVariables.materialsFile);
                (_, Artist artistInAlbum) = GetFromIDs<Artist>.get(materialInAlbum.Editor, GlobalVariables.artistsFile);
                GetFromIDs<Editor>.get(artistInAlbum.Editor, GlobalVariables.editorsFile).Item2.addComment(comment);
            }
        }
        public static void Approved(Comment comment)
        {
            (bool have, Member member) = GetFromIDs<Member>.get(comment.reviewer, GlobalVariables.membersFile);
            if (have)
            {
                member.LeaveComment(comment);
            }
            (have, Material material) = GetFromIDs<Material>.get(comment.idOfPlaceholder, GlobalVariables.materialsFile);
            if (have)
            {
                MaterialService.LeaveComment(material,comment);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(comment.idOfPlaceholder, GlobalVariables.artistsFile);
            if ((have))
            {
                ArtistService.LeaveComment(artist, comment);
            }

        }
    }
}
