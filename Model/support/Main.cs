using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using muzickiKatalog.Model.support;
using muzickiKatalog.Model.dao;
using muzickiKatalog.Model.Domain.performatorium;
using muzickiKatalog.Model.Domain.contributors;

namespace muzickiKatalog.Model.support
{
    public class Main
    {
        public Main() {
            emptyall();
            generateAdmin();
            generateArtists();
            generateEditors();
            generateGroups();
            generateMaterials();
            generateMembers();
        }

        public void generateEditors() {
            new Editor("nicole@editor.com", "pass", "Nicole", "Julius", Gender.male, new DateOnly(1879, 3, 14), new List<string>() { "jazz" });
        }
        public void generateMembers() {
            new Member("albert@member.com", "pass", "Albert", "Einstein", Gender.male, new DateOnly(1879, 3, 14));
            new Member("marie@member.com", "pass", "Marie", "Curie", Gender.female, new DateOnly(1867, 11, 7));
            new Member("isaac@member.com", "pass", "Isaac", "Newton", Gender.male, new DateOnly(1643, 1, 4));
            new Member("ada@member.com", "pass", "Ada", "Lovelace", Gender.female, new DateOnly(1815, 12, 10));
            new Member("charles@member.com", "pass", "Charles", "Darwin", Gender.male, new DateOnly(1809, 2, 12));
            new Member("rosalind@member.com", "pass", "Rosalind", "Franklin", Gender.female, new DateOnly(1920, 7, 25));
            new Member("stephen@member.com", "pass", "Stephen", "Hawking", Gender.male, new DateOnly(1942, 1, 8));
            new Member("jane@member.com", "pass", "Jane", "Goodall", Gender.female, new DateOnly(1934, 4, 3));
            new Member("niels@member.com", "pass", "Niels", "Bohr", Gender.male, new DateOnly(1885, 10, 7));
            new Member("mae@member.com", "pass", "Mae", "Jemison", Gender.female, new DateOnly(1956, 10, 17));
         }
        public void generateAdmin() {
            new Admin(1, "admin@admin.com", "pass");
        }
        public void generateGroups() {
            
        }
        public void generateMaterials() {

        }
        public void generateArtists()
        {
            new Artist("nicole@editor.com", "John", "Doe", Gender.male, new DateOnly(1985, 7, 15), "John Doe is a versatile jazz singer known for his smooth vocals and improvisational skills.", artistType.singer, new List<string>() { "jazz" });
            new Artist("nicole@editor.com", "Jane", "Smith", Gender.female, new DateOnly(1990, 3, 22), "Jane Smith is a prolific songwriter in the rock genre, blending heartfelt lyrics with powerful melodies.", artistType.songWriter, new List<string>() { "rock" });
            new Artist("nicole@editor.com", "Michael", "Johnson", Gender.male, new DateOnly(1982, 9, 5), "Michael Johnson is a conductor renowned for his precise interpretations and dynamic performances with orchestras worldwide.", artistType.conductor, new List<string>() { "classical" });
            new Artist("nicole@editor.com", "Emily", "Davis", Gender.female, new DateOnly(1987, 12, 10), "Emily Davis is an acclaimed instrumentalist, known for her virtuosity on the violin and her innovative approach to classical and contemporary music.", artistType.instrumentalist, new List<string>() { "classical", "hiphop" });
            new Artist("nicole@editor.com", "David", "Brown", Gender.male, new DateOnly(1978, 5, 3), "David Brown is a versatile composer, celebrated for his film scores that capture the emotional depth of each scene with intricate orchestrations and memorable themes.", artistType.composer, new List<string>() { "country" });
            new Artist("nicole@editor.com", "Sarah", "Garcia", Gender.female, new DateOnly(1989, 11, 18), "Sarah Garcia is a talented producer known for her innovative sound design and ability to create chart-topping hits across various genres.", artistType.producer, new List<string>() { "pop", "blues" });
            new Artist("nicole@editor.com", "Alex", "Martinez", Gender.male, new DateOnly(1983, 2, 28), "Alex Martinez is a renowned DJ recognized for his electrifying performances and seamless mixes that keep audiences dancing all night long.", artistType.dj, new List<string>() { "electronic" });
            new Artist("nicole@editor.com", "Jessica", "Robinson", Gender.female, new DateOnly(1984, 8, 7), "Jessica Robinson is a trailblazing rapper known for her empowering lyrics and fierce delivery, addressing social issues and inspiring change through her music.", artistType.rapper, new List<string>() { "hiphop", "rap" });
            new Artist("nicole@editor.com", "Mark", "Wilson", Gender.male, new DateOnly(1981, 10, 12), "Mark Wilson is an influential singer-songwriter known for his introspective lyrics and soulful voice, touching hearts with his heartfelt ballads and anthems.", artistType.songWriter, new List<string>() { "folk", "rnb" });
            new Artist("nicole@editor.com", "Rachel", "Lee", Gender.female, new DateOnly(1986, 6, 25), "Rachel Lee is a dynamic instrumentalist mastering multiple instruments and genres, from classical violin to jazz piano, pushing boundaries and redefining musical versatility.", artistType.instrumentalist, new List<string>() { "classical", "jazz" });
        
        }
        public void emptyall()
        {
        
            new Dao<User>(GlobalVariables.usersFile).WriteDictionaryToFile(new Dictionary<string, User>());
            new Dao<Editor>(GlobalVariables.editorsFile).WriteDictionaryToFile(new Dictionary<string, Editor>());
            new Dao<Member>(GlobalVariables.membersFile).WriteDictionaryToFile(new Dictionary<string, Member>());
            new Dao<Artist>(GlobalVariables.artistsFile).WriteDictionaryToFile(new Dictionary<string, Artist>());
            new Dao<Text>(GlobalVariables.textsFile).WriteDictionaryToFile(new Dictionary<string, Text>());
        }
    }
}
