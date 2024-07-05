using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Controller.performatorium;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Model.performatorium;
namespace muzickiKatalog.Layers.Controller.contributors
{
    public class MemberController
    {
        public static (Dictionary<string,Tuple<string,string>>,Dictionary<string,Tuple<string,string>>) followingArtistsAndGroups(Member member,Dictionary<string, Artist> allArtists,Dictionary<string,Group> allGroups) {
            Dictionary<string,Artist> artists= new Dictionary<string,Artist>();
            Dictionary<string, Group> groups = new Dictionary<string, Group>();
            foreach (string item in member.following)
            {
                if (allArtists.ContainsKey(item)) { artists.Add(item, allArtists[item]); }
                else { groups.Add(item, allGroups[item]); }
            }
            return (ArtistController.getForList(artists), GroupController.getForList(groups));
        }
    }
}
