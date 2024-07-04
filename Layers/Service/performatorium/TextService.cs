using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Repository.performatorium;

namespace muzickiKatalog.Layers.Service.performatorium
{
    public class TextService
    {
        public static Text getTextByID(string id)
        {
            return TextRepository.getAll()[id];
        }
    }
}
