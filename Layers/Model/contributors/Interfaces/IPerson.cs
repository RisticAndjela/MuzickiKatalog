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
        public string name { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public DateOnly birthday { get; set; }
    }
}
