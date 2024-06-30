using muzickiKatalog.Layers.support.IDparser;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class Comment
    {
        public string reviewer { get; set; }
        public string commentedOn {  get; set; }// id of biography or concert or wtvr 
        public string comment { get; set; }
        public DateTime reviewed { get; set; }
   
        public Comment() {}
        public Comment(string _reviewer, string _comment, DateTime _reviewed, string _commentedOn)
        {
            reviewer = _reviewer;
            comment = _comment;
            reviewed = _reviewed;
            commentedOn = _commentedOn;
            (bool have, Material material) = GetFromIDs<Material>.get(commentedOn, GlobalVariables.materialsFile);
            if (have)
            {
                GetFromIDs<Editor>.get(material.editor, GlobalVariables.editorsFile).Item2.addComment(this);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(commentedOn, GlobalVariables.artistsFile);
            if ((have))
            {
                GetFromIDs<Editor>.get(artist.editor, GlobalVariables.editorsFile).Item2.addComment(this);
            }
        }
        public void approved()
        {
            (bool have, Member member)=GetFromIDs<Member>.get(reviewer,GlobalVariables.membersFile);
            if (have) {
                member.LeaveComment(this);
            }
            (have, Material material) = GetFromIDs<Material>.get(commentedOn, GlobalVariables.materialsFile);
            if (have)
            {
                material.leaveComment(this);
            }
            (have, Artist artist) = GetFromIDs<Artist>.get(commentedOn, GlobalVariables.artistsFile);
            if ((have))
            {
                artist.LeaveComment(this);
            }
            
        }

    }
}
