using muzickiKatalog.Layers.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.contributors.Interfaces
{
    public interface IPerson
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender GenderProp { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
