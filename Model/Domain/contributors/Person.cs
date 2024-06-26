using muzickiKatalog.Model.support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Model.Domain.contributors
{
    public class Person
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public DateOnly birthday { get; set; }

        public Person() { }
        public Person(string username, string password,string _name, string _lastName, Gender _gender, DateOnly _birthday,personType type)
        {
            if (type != personType.artist)
            {
                new User(username, password, type);
            }
            name = _name;
            lastName = _lastName;
            gender = _gender;
            birthday = _birthday;
        }
    }
}
