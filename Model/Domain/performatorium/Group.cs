using muzickiKatalog.Model.dao;
using muzickiKatalog.Model.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Model.Domain.performatorium
{
    public class Group
    {
        public string name {  get; set; }
        public List<Artist> artists { get; set; } = new List<Artist>();
        
        public Group() { }
        public Group(List<Artist> _artists)
        {
            artists = _artists;
            save();
        }
        public void save()
        {
            SaveOneInstance<Group>.SaveOneInstanceInDictionary(this, MakeIDs.makeGroupID(this), GlobalVariables.groupsFile);
            foreach (Artist artist in artists)
            {
                artist.addGroupInfo(this);
            }
        }
    }
}
