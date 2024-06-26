using muzickiKatalog.Model.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Model.Domain.contributors
{
    public class Admin
    {
        public Admin() { }
        public Admin(int id,string username, string password) {
            new User(username, password,personType.admin);
        }

    }
}
