using muzickiKatalog.Layers.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.performatorium
{
    //long texts such as description for videos and biography for artists and groups
    public class Text
    {
        public string text;
        public Text() { }
        public Text(string _text, string id)
        {
            text = _text;
            save(id);
        }
        public void save(string id)
        {
            SaveOneInstance<Text>.SaveOneInstanceInDictionary(this, id, GlobalVariables.textsFile);
        }
    }
}
