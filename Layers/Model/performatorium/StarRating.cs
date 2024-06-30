using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class StarRating
    {
        public string reviewer { get; set; }
        public string ratedOn { get; set; }// id of biography or concert or wtvr 
        public int rating { get; set; }
        public DateTime reviewed { get; set; }

        public StarRating() { }
        public StarRating(string _reviewer, int _rating, DateTime _reviewed, string _ratedOn) {
            reviewer = _reviewer;
            rating = _rating;
            reviewed = _reviewed;
            ratedOn = _ratedOn;
            (bool have, Material material) = GetFromIDs<Material>.get(ratedOn, GlobalVariables.materialsFile);
            if (have)
            {
                GetFromIDs<Editor>.get(material.editor, GlobalVariables.editorsFile).Item2.addRating(this);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(ratedOn, GlobalVariables.artistsFile);
            if ((have))
            {
                GetFromIDs<Editor>.get(artist.editor, GlobalVariables.editorsFile).Item2.addRating(this);
            }
        }

        public void approved()
        {
            (bool have, Member member) = GetFromIDs<Member>.get(reviewer, GlobalVariables.membersFile);
            if (have)
            {
                member.LeaveRating(this);
            }
            (have, Material material) = GetFromIDs<Material>.get(ratedOn, GlobalVariables.materialsFile);
            if (have)
            {
                material.leaveRating(this);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(ratedOn, GlobalVariables.artistsFile);
            if ((have))
            {
                artist.LeaveRating(this);
            }

        }
    }
}
