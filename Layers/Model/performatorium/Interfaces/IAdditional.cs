using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IAdditional
    {
        public int Visits { get; set; }
        public List<string> Media { get; set; }
        public List<Comment> AllComments { get; set; }
        public List<StarRating> AllStarRatings { get; set; }
        public void LeaveComment(Comment comment) { }
        public void LeaveRating(StarRating rating) { }
    }
}
