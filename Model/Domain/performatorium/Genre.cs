using muzickiKatalog.Model.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Model.Domain.performatorium
{
    public class Genre
    {
        public string name { get; set; }
        public Genre() { }
        public Genre(string _name)
        {
            name = _name;
            save();
        }

        private void save()
        {
            SaveOneInstance<Genre>.SaveOneInstanceInList(this, GlobalVariables.genresFile);
        }
    }
}
