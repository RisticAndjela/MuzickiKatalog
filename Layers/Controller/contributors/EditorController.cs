using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Controller.contributors
{
    public class EditorController
    {
        //materials, albums,artists,groups
        public static (Dictionary<string,Tuple<string,string>>, Dictionary<string, Tuple<string, string>>, Dictionary<string, Tuple<string, string>>, Dictionary<string, Tuple<string, string>>) getTasks(Editor editor ,Dictionary<string, Material> allMaterials, Dictionary<string, Album> allAlbums, Dictionary<string, Artist> allArtists, Dictionary<string, Group> allGroups)
        {
            Dictionary<string,Material> materials = new Dictionary<string,Material>();
            Dictionary<string,Album> albums=new Dictionary<string,Album>();
            Dictionary<string,Artist> artists=new Dictionary<string,Artist>();
            Dictionary<string,Group> groups=new Dictionary<string,Group>();

            foreach (string id in editor.needToLeaveReviews)
            {
                if (allMaterials.ContainsKey(id)) { materials[id] = allMaterials[id]; }
                if(allAlbums.ContainsKey(id)) { albums[id]=allAlbums[id]; }
                if (allArtists.ContainsKey(id)) { artists[id]=allArtists[id]; }
                if(allGroups.ContainsKey(id)) {  groups[id]=allGroups[id]; }
            }
            return (MaterialController.getForList(materials),AlbumController.getForList(albums),ArtistController.getForList(artists),GroupController.getForList(groups));
        }
        public static Dictionary<string,Tuple<string,string>> getReviews(Editor editor)
        {
            var final= getForList(editor.needToApproveComments).ToDictionary();
            foreach (var kvp in getForList(editor.needToApproveRatings).ToDictionary())
            {
                final[kvp.Key] = kvp.Value;
            }
            return final;
        }
    
        public static Dictionary<string, Tuple<string, string>> getForList(List< Comment> comments)
        {
        Dictionary<string, Tuple<string, string>> allcomments = new Dictionary<string, Tuple<string, string>>();
        foreach ( Comment comment in comments)
        {
                if (allcomments.ContainsKey($"{comment.idOfPlaceholder}...{comment.comment}")) { continue; }
            allcomments.Add($"{comment.idOfPlaceholder}...{comment.comment}", new Tuple<string, string>($"Comment: {comment.comment}, commentator{comment.reviewer}", getMedia(comment.idOfPlaceholder)));
        }
        return allcomments;
        }
        public static Dictionary<string, Tuple<string, string>> getForList(List<StarRating> ratings)
        {
            Dictionary<string, Tuple<string, string>> allratings = new Dictionary<string, Tuple<string, string>>();
            foreach (StarRating rating in ratings)
            {
                if (allratings.ContainsKey($"{rating.idOfPlaceholder}...{rating.rating}")) { continue; }
                allratings.Add($"{rating.idOfPlaceholder}...{rating.rating}", new Tuple<string, string>($"{string.Concat(Enumerable.Repeat($"★", rating.rating))} commentator{ rating.reviewer}", getMedia(rating.idOfPlaceholder)));
            }
            return allratings;
        }
        public static string getMedia(string id)
        {
            (bool have, Artist artist) = GetFromIDs<Artist>.get(id, GlobalVariables.artistsFile);
            if (have) { return artist.Media[0]; }
            (have, Album album) = GetFromIDs<Album>.get(id, GlobalVariables.albumsFile);
            if (have) { return album.Media[0]; }
            (have, Material material) = GetFromIDs<Material>.get(id, GlobalVariables.materialsFile);
            if (have) { return material.Media[0]; }
            (have, Group group) = GetFromIDs<Group>.get(id, GlobalVariables.groupsFile);
            if (have) { return group.Media[0]; }
            return null;
        }
    }
}
