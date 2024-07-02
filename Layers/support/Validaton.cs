using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.support
{
    public class Validation
    {
        public static (bool, string) ValidateAndMakeMember(string username, string password, string name, string lastname, Gender gender, DateOnly birthday)
        {
            if (string.IsNullOrEmpty(username)) { return (false, "Username empty"); }
            if (string.IsNullOrEmpty(password)) { return (false, "password empty"); }
            if (string.IsNullOrEmpty(name)) { return (false, "Name empty"); }
            if (string.IsNullOrEmpty(lastname)) { return (false, "last Name empty"); }
            if (birthday > DateOnly.FromDateTime(DateTime.Now).AddYears(3)) { return (false, "not old enough"); }
            if (!uniqueUsername(username)) { return (false, "Username already taken"); }
            new Member(username, password, name, lastname, gender, birthday);
            return (true, "");
        }
        public static bool uniqueUsername(string username)
        {
            (bool have, User user) = GetFromIDs<User>.get(username, GlobalVariables.usersFile);
            return !have;
        }
    }
}
