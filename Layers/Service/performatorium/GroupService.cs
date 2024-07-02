using muzickiKatalog.Layers.Model.performatorium;
using performatoriumNS=muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Service.performatorium.Interfaces;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class GroupService:IGroupService
    {
        public static void visited(Group group)
        {
            group.Visits++;
            GroupRepository.save(group);
        }
        public static void addMaterial(Group group, performatoriumNS.Material material)
        {
            group.AllMaterials.Add(MakeIDs.makeMaterialID(material));
            GroupRepository.save(group);
            foreach (string s in group.Artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                ArtistService.AddMaterialInfo(artist, material);
            }
        }
        public static void addAlbum(Group group, Album album)
        {
            group.AllMaterials.Add(MakeIDs.makeAlbumID(album));
            GroupRepository.save(group);
            foreach (string s in group.Artists)
            {
                (_, Artist artist) = GetFromIDs<Artist>.get(s, GlobalVariables.artistsFile);
                ArtistService.AddAlbumInfo(artist,album);
            }
        }
        public static void addComment(Group group, Comment comment)
        {
            group.AllComments.Add(comment);
            GroupRepository.save(group);
        }
        public static void addRating(Group group, StarRating stars)
        {
            group.AllStarRatings.Add(stars);
            GroupRepository.save(group);
        }
        public static Dictionary<string, Group> get10Popular()
        {
            Dictionary<string, Group> popular = new Dictionary<string, Group>();
            Dictionary<string, Group> all = GroupRepository.getAll();
            Dictionary<int, string> allRatings = new Dictionary<int, string>();
            foreach (KeyValuePair<string, Group> pair in all)
            {
                allRatings.Add(calculateRating(pair.Value), pair.Key);
            }
            List<string> sortedRatings = allRatings.OrderBy(x => x.Key).Select(x => x.Value).ToList<string>();
            for (int i = 0; i < 10; i++)
            {
                if (sortedRatings.Count < i) { break; }
                popular.Add(sortedRatings[i], all[sortedRatings[i]]);
            }
            return popular;

        }
        public static int calculateRating(Group group)
        {
            int rating = 0;
            
            int reviews = group.AllComments.Count * 2 + group.AllStarRatings.Count;
            switch (reviews)
            {
                case < 10:
                    rating += 5;
                    break;
                case < 20:
                    rating += 10;
                    break;
                case < 40:
                    rating += 35;
                    break;
                case < 50:
                    rating += 60;
                    break;
            }
            return rating;
        }
    }
}
