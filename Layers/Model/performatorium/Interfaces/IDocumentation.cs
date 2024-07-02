using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IDocumentation : IAdditional
    {
        public List<string> AllMaterials { get; set; }
        
        }
}
