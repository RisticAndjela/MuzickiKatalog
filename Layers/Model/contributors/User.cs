using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Model.contributors
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public personType type { get; set; }
        
        public User() { }
        public User(string _username, string _password,personType _type)
        {
            username = _username;
            password=_password;
            type = _type;
            save();
        }
        public void save()
        {
            SaveOneInstance<User>.SaveOneInstanceInDictionary(this,username, GlobalVariables.usersFile);
        }
    }
}