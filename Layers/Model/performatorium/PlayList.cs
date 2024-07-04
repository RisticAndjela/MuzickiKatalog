using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Repository.performatorium;
using muzickiKatalog.Layers.support.IDparser;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class PlayList
    {
        public string owner { get; set; }
        public string Name { get; set; }
        public bool isPrivate {  get; set; }
        public List<string> materials { get; set; }=new List<string>();
        public PlayList() { }
        public PlayList(Member member,string name,bool _isPrivate) {
            owner = member.username;
            Name=name;
            isPrivate=_isPrivate;
            PlayListRepository.save(this);
        }
    }
}
