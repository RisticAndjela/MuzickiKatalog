using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium.Interfaces
{
    public interface IGroup: IDocumentation
    {
        public string Name { get; set; }
        public DateOnly Started { get; set; }
        public bool isActive { get; set; }
        public List<string> Artists { get; set; }
    }
}
