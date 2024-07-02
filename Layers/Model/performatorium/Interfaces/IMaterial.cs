using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IMaterial: IAdditional
    {
        public string Editor { get; set; }
        public string Title { get; set; }
        public DateOnly PublishDate { get; set; }
        public DateOnly PerformedDate { get; set; }
        public string Genre { get; set; }
        public string Albums { get; set; } 
        public List<string> Contributors { get; set; }
        
    }
}
