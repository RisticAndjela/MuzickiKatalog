using muzickiKatalog.Layers.support;
using muzickiKatalog.Layers.Model.contributors.Interfaces;

namespace muzickiKatalog.Layers.Model.contributors
{
    public abstract class Person: IPerson
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
