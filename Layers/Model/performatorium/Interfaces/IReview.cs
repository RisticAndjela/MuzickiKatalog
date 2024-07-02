using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IReview
    {
        public string reviewer { get; set; }
        public string idOfPlaceholder { get; set; }// id of biography or concert or wtvr 
        public DateTime reviewed { get; set; }
    }
}
