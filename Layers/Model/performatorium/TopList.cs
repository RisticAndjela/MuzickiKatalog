using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium
{
    public class TopList
    {
        public string Name { get; set; }   
        public string Description { get; set; }
        public DateOnly startDate {  get; set; }
        public DateOnly endDate { get; set; }
        public Dictionary<string,int> votes { get; set; } //id : number of votes
        public TopList() { }
        public TopList(string name, string description, DateOnly start, DateOnly end, List<string> options) {
        
            Name = name;
            Description = description;
            startDate = start;
            endDate = end;
            foreach (string s in options) { 
                votes.Add(s,0);
            }
        }
    }
}
