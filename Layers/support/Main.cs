using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.performatorium;
using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.support.IDparser;
using contributor=muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Service.performatorium;
namespace muzickiKatalog.Layers.support
{
    public class Main
    {
        public Main() {
            //everything();
        }
        public void everything()
        {
            emptyall();
            generateAdmin();
            generateGenres();
            generateArtists();
            generateEditors();
            generateGroups();
            generateMaterials();
            generateMembers();
            generateAlbums();
            generateSongs();
            generatePlayLists();
        }
        public void generatePlayLists()
        {
            PlayList playList = new PlayList(GetFromIDs<contributor.Member>.get("marie@member.com", GlobalVariables.membersFile).Item2, "new playlist", true);
            PlayListService.addMaterialbyID(playList, "The History of Classical Music:Brown-");
            PlayListService.addMaterialbyID(playList, "Introduction to Music Theory:Martinez-");
            PlayListService.addMaterialbyID(playList, "The Evolution of Rock Music:Martinez-");
            PlayListService.addMaterialbyID(playList, "'The Dark Side of the Moon' Album:Speak to Me:Pink Floyd-Breathe:Pink Floyd-On the Run:Pink Floyd-Time:Pink Floyd-The Great Gig in the Sky:Pink Floyd-Money:Pink Floyd-Us and Them:Pink Floyd-Any Colour You Like:Pink Floyd-Brain Damage:Pink Floyd-Eclipse:Pink Floyd-");
        }

        public void generateGenres()
        {
            new Genre("rock");
            new Genre("pop");
            new Genre("jazz");
            new Genre("classical");
            new Genre("hiphop");
            new Genre("electronic");
            new Genre("country");
            new Genre("blues");
            new Genre("rnb");
            new Genre("folk");
            new Genre("metal");
            new Genre("punk");
            new Genre("rap");
            new Genre("music theory");
            new Genre("gospel");
            new Genre("world");

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
            // pink floyd
            new Artist("nicole@editor.com", "Roger", "Waters", Gender.male, new DateOnly(1943, 9, 6), "Roger Waters is a founding member and bassist of Pink Floyd, known for his songwriting and concept albums.", artistType.singer, new List<string>() { "progressive rock", "psychedelic rock" }, new List<string>() { GlobalVariables.pink_floyd});
            new Artist("nicole@editor.com", "David", "Gilmour", Gender.male, new DateOnly(1946, 3, 6), "David Gilmour is a guitarist, vocalist, and songwriter, known for his distinctive guitar playing and contributions to Pink Floyd's sound.", artistType.singer, new List<string>() { "progressive rock", "psychedelic rock" }, new List<string>() { GlobalVariables.pink_floyd });
            new Artist("nicole@editor.com", "Nick", "Mason", Gender.male, new DateOnly(1944, 1, 27), "Nick Mason is the drummer and percussionist for Pink Floyd, known for his precise and innovative drumming style.", artistType.singer, new List<string>() { "progressive rock", "psychedelic rock" }, new List<string>() { GlobalVariables.pink_floyd });
            new Artist("nicole@editor.com", "Richard", "Wright", Gender.male, new DateOnly(1943, 7, 28), "Richard Wright was a keyboardist and founding member of Pink Floyd, known for his atmospheric keyboard textures and contributions to the band's compositions.", artistType.singer, new List<string>() { "progressive rock", "psychedelic rock" }, new List<string>() { GlobalVariables.pink_floyd });
            new Artist("nicole@editor.com", "Syd", "Barrett", Gender.male, new DateOnly(1946, 1, 6), "Syd Barrett was a founding member of Pink Floyd and a guitarist and songwriter known for his innovative psychedelic rock contributions.", artistType.singer, new List<string>() { "psychedelic rock" }, new List<string>() { GlobalVariables.pink_floyd });
            new Group("Pink Floyd", new DateOnly(1965, 2, 27), false, new List<string>() { "Syd_Barrett_1/6/1946", "Richard_Wright_7/28/1943", "Nick_Mason_1/27/1944", "David_Gilmour_3/6/1946", "Roger_Waters_9/6/1943" }, new List<string>() { GlobalVariables.pink_floyd }, "Pink Floyd is a legendary rock band known for their progressive and psychedelic rock music, influencing generations with albums like 'The Dark Side of the Moon' and 'The Wall'.");
            // The Beatles 
            new Artist("nicole@editor.com", "John", "Lennon", Gender.male, new DateOnly(1940, 10, 9), "John Lennon was a singer, songwriter, and guitarist, known for his role as a co-founder of The Beatles and his solo career.", artistType.singer, new List<string>() { "rock", "pop" }, new List<string>() { GlobalVariables.beatles });
            new Artist("nicole@editor.com", "Paul", "McCartney", Gender.male, new DateOnly(1942, 6, 18), "Paul McCartney is a singer, songwriter, and multi-instrumentalist, known for his work as a co-founder of The Beatles and his successful solo career.", artistType.singer, new List<string>() { "rock", "pop" }, new List<string>() { GlobalVariables.beatles });
            new Artist("nicole@editor.com", "George", "Harrison", Gender.male, new DateOnly(1943, 2, 25), "George Harrison was a guitarist, singer, and songwriter, known for his contributions to The Beatles and his exploration of Indian music and spirituality.", artistType.singer, new List<string>() { "rock", "pop" }, new List<string>() { GlobalVariables.beatles });
            new Artist("nicole@editor.com", "Ringo", "Starr", Gender.male, new DateOnly(1940, 7, 7), "Ringo Starr is a drummer, singer, and actor, best known as the drummer for The Beatles and for his solo music career.", artistType.singer, new List<string>() { "rock", "pop" }, new List<string>() { GlobalVariables.beatles });
            new Group("The Beatles", new DateOnly(1960, 8, 18), false, new List<string>() { "John_Lennon_10/9/1940", "Paul_McCartney_6/18/1942", "George_Harrison_2/25/1943", "Ringo_Starr_7/7/1940" }, new List<string>() { GlobalVariables.beatles }, "The Beatles were a groundbreaking rock band from Liverpool, England, that revolutionized popular music in the 1960s.");
            // The Rolling Stones 
            new Artist("nicole@editor.com", "Mick", "Jagger", Gender.male, new DateOnly(1943, 7, 26), "Mick Jagger is a singer, songwriter, and frontman of The Rolling Stones, known for his dynamic stage presence and iconic voice.", artistType.singer, new List<string>() { "rock", "blues" }, new List<string>() { GlobalVariables.rolling_stones });
            new Artist("nicole@editor.com", "Keith", "Richards", Gender.male, new DateOnly(1943, 12, 18), "Keith Richards is a guitarist, songwriter, and founding member of The Rolling Stones, known for his innovative guitar riffs and songwriting contributions.", artistType.singer, new List<string>() { "rock", "blues" }, new List<string>() { GlobalVariables.rolling_stones });
            new Artist("nicole@editor.com", "Charlie", "Watts", Gender.male, new DateOnly(1941, 6, 2), "Charlie Watts was the drummer of The Rolling Stones, known for his steady rhythm and jazz-influenced drumming style.", artistType.singer, new List<string>() { "rock", "blues" }, new List<string>() { GlobalVariables.rolling_stones });
            new Artist("nicole@editor.com", "Ronnie", "Wood", Gender.male, new DateOnly(1947, 6, 1), "Ronnie Wood is a guitarist and bassist, known for his work with The Rolling Stones and his earlier work with Faces and The Jeff Beck Group.", artistType.singer, new List<string>() { "rock", "blues" }, new List<string>() { GlobalVariables.rolling_stones });
            new Group("The Rolling Stones", new DateOnly(1962, 7, 12), true, new List<string>() { "Mick_Jagger_7/26/1943", "Keith_Richards_12/18/1943", "Charlie_Watts_6/2/1941", "Ronnie_Wood_6/1/1947" }, new List<string>() { GlobalVariables.rolling_stones }, "The Rolling Stones are a legendary rock band known for their bluesy sound, energetic performances, and enduring influence on rock 'n' roll.");

        }
        public void generateAlbums()
        {
            List<string> songTitles = new List<string>{"Speak to Me","Breathe","On the Run","Time","The Great Gig in the Sky","Money","Us and Them","Any Colour You Like","Brain Damage","Eclipse"};
            List<string> ids=new List<string>();
            foreach (string songTitle in songTitles)
            {
                Material m=new Material("nicole@editor.com", songTitle, new List<string>(){ "blues" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("12.12.2002"), new List<string> { "Pink Floyd:Barrett-Wright-Mason-Gilmour-Waters-" }, new List<string>() { GlobalVariables.pink_floyd }, $"\"{songTitle}\" is a track from 'The Dark Side of the Moon' Album.");
                ids.Add(MakeIDs.makeMaterialID(m));
            }
            new Album("'The Dark Side of the Moon' Album","blues", ids, new List<string>() { GlobalVariables.pink_floyd }, "'The Dark Side of the Moon' by Pink Floyd is revered for its musical innovation, thought-provoking lyrics, and seamless blend of progressive rock, psychedelia, and experimental soundscapes.");

        }
        public void generateMaterials() {
            new Material("nicole@editor.com", "Introduction to Music Theory", new List<string>() { "music theory" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2002-12-12"), new List<string> { "Alex_Martinez_2/28/1983" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "This comprehensive guide covers the basics of music theory, including scales, chords, and key signatures, providing a solid foundation for beginners and a refresher for seasoned musicians.");
            new Material("nicole@editor.com", "The History of Classical Music", new List<string>() { "classical" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1998-09-20"), new List<string> { "David_Brown_5/3/1978" }, new List<string>() { GlobalVariables.img4, GlobalVariables.img3 }, "Explore the rich history of classical music, from its origins in the medieval period to its development through the Baroque, Classical, and Romantic eras, and its influence on contemporary music.");
            new Material("nicole@editor.com", "Understanding Jazz Improvisation", new List<string>() { "jazz" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985", "David_Brown_5/3/1978", "Rachel_Lee_6/25/1986" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Delve into the world of jazz improvisation with this detailed guide, explaining the techniques and theories behind spontaneous composition, and offering practical exercises to develop your improvisational skills.");
            new Material("nicole@editor.com", "The Evolution of Rock Music", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Alex_Martinez_2/28/1983" }, new List<string>() { GlobalVariables.img4, GlobalVariables.img3 }, "Trace the evolution of rock music from its roots in blues and country to its rise in the 1950s, the British Invasion, the punk movement, and its continued influence on today's music scene.");
            new Material("nicole@editor.com", "The Role of the Conductor", new List<string>() { "orchestra" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Jessica_Robinson_8/7/1984" }, new List<string>() { GlobalVariables.img2, GlobalVariables.img3 }, "Learn about the pivotal role of the conductor in orchestral performances, including their responsibilities in interpreting scores, leading rehearsals, and ensuring cohesive and expressive performances.");
            new Material("nicole@editor.com", "The Impact of Digital Technology on Music Production", new List<string>() { "music theory" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985", "Rachel_Lee_6/25/1986" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Examine how digital technology has revolutionized music production, from recording and editing to distribution, and how these advancements have democratized music creation and altered the music industry landscape.");
            new Material("nicole@editor.com", "Exploring World Music Traditions", new List<string>() { "world" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Discover the diverse musical traditions from around the globe, including the instruments, rhythms, and cultural contexts that shape the music of Africa, Asia, the Americas, and beyond.");
            new Material("nicole@editor.com", "The Psychology of Music", new List<string>() { "music theory" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Emily_Davis_12/10/1987", "Alex_Martinez_2/28/1983" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Explore the psychological aspects of music, including how it affects our emotions, cognition, and behavior, and the ways in which music therapy can be used to support mental health and well-being.");
            new Material("nicole@editor.com", "Film Scoring Techniques", new List<string>() { "music theory" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Gain insights into the art of film scoring, including the techniques used to create mood, enhance storytelling, and evoke emotions, with examples from iconic movie soundtracks.");
            new Material("nicole@editor.com", "The Business of Music", new List<string>() { "music theory" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "David_Brown_5/3/1978" },  new List<string>() { GlobalVariables.img2, GlobalVariables.img3 }, "Navigate the complexities of the music business, from contracts and copyright to marketing and management, providing aspiring musicians and industry professionals with the knowledge needed to succeed in the music industry.");
            new Material("nicole@editor.com", "Mozart's 'The Magic Flute' Opera", new List<string>() { "opera" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Rachel_Lee_6/25/1986" }, new List<string>() { GlobalVariables.img3, GlobalVariables.img1 }, "'The Magic Flute' is Mozart's famous opera that blends myth, magic, and music to tell a fantastical tale of love, wisdom, and the triumph of good over evil.");
            new Material("nicole@editor.com", "Beethoven's Symphony No. 9: 'Ode to Joy'", new List<string>() { "classical" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985" }, new List<string>() { GlobalVariables.img4, GlobalVariables.img3 }, "Beethoven's Symphony No. 9, particularly its final movement 'Ode to Joy', is celebrated for its powerful expression of universal brotherhood and joy, making it a landmark in classical music history.");
            new Material("nicole@editor.com", "The Beatles: 'Sgt. Pepper's Lonely Hearts Club Band' Album", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Mark_Wilson_10/12/1981" },   new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Explore 'Sgt. Pepper's Lonely Hearts Club Band', The Beatles' groundbreaking album that redefined the possibilities of studio recording and became an emblem of the 1960s counterculture.");
            new Material("nicole@editor.com", "Miles Davis: 'Kind of Blue' Album", new List<string>() { "jazz" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Emily_Davis_12/10/1987" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Dive into 'Kind of Blue', Miles Davis' masterpiece that revolutionized jazz with its modal jazz style, improvisational brilliance, and timeless compositions.");
            new Material("nicole@editor.com", "Puccini's 'La Bohème' Opera", new List<string>() { "opera" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985" }, new List<string>() { GlobalVariables.img2, GlobalVariables.img3 }, "'La Bohème' is Puccini's poignant opera depicting the lives of struggling artists in Paris, celebrated for its melodic richness and emotional depth.");
            new Material("nicole@editor.com", "Woodstock Music Festival 1969: Cultural Impact and Legacy", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "Mark_Wilson_10/12/1981" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 }, "Explore the cultural impact and enduring legacy of the iconic Woodstock Music Festival of 1969, a landmark event in the history of rock music and youth culture.");
            new Material("nicole@editor.com", "The Rolling Stones: 'Exile on Main St.' Album", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2005-03-10"), new List<string> { "John_Doe_7/15/1985", "Jessica_Robinson_8/7/1984" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 },"'Exile on Main St.' is The Rolling Stones' double album known for its raw energy, eclectic mix of genres, and evocative storytelling, capturing the essence of rock 'n' roll.");
            new Material("nicole@editor.com", "Johann Strauss II: 'The Blue Danube' Waltz", new List<string>() { "classical" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("2006-11-12"), new List<string> { "Michael_Johnson_9/5/1982" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img2 }, "Experience the enchanting 'Blue Danube' Waltz by Johann Strauss II, a masterpiece of Viennese waltz music beloved for its flowing melodies and elegant charm.");
        }
        public void generateSongs()
        {
            new Artist("nicole@editor.com", "Elvis", "Presley", Gender.male, new DateOnly(1935, 1, 8), "Elvis Presley is widely regarded as the King of Rock 'n' Roll, known for his charismatic stage presence and influential blend of rockabilly, gospel, and blues.", artistType.singer, new List<string>() { "rock", "gospel", "blues" }, new List<string>() { GlobalVariables.elvis_presley });
            new Material("nicole@editor.com", "Elvis Presley's 'Can't Help Falling in Love'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1961-10-01"), new List<string> { "Elvis_Presley_1/8/1935" }, new List<string>() { GlobalVariables.elvis_presley }, "'Can't Help Falling in Love' is one of Elvis Presley's most iconic songs, known for its beautiful melody and heartfelt lyrics that capture the essence of romance and enduring love.");
            new Material("nicole@editor.com", "Elvis Presley's 'Jailhouse Rock'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1957-09-24"), new List<string> { "Elvis_Presley_1/8/1935" }, new List<string>() { GlobalVariables.elvis_presley }, "'Jailhouse Rock' is a famous rock and roll song by Elvis Presley, known for its energetic beat and iconic dance sequence in the film of the same Name.");
            new Material("nicole@editor.com", "Elvis Presley's 'Suspicious Minds'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1969-08-26"), new List<string> { "Elvis_Presley_1/8/1935" }, new List<string>() { GlobalVariables.elvis_presley }, "'Suspicious Minds' is a soulful ballad by Elvis Presley, notable for its emotional depth and powerful vocal performance.");
            new Material("nicole@editor.com", "Elvis Presley's 'Heartbreak Hotel'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1956-01-27"), new List<string> { "Elvis_Presley_1/8/1935" }, new List<string>() { GlobalVariables.elvis_presley }, "'Heartbreak Hotel' marked Elvis Presley's debut as a rock and roll icon, capturing the loneliness and despair of lost love.");
            new Material("nicole@editor.com", "Elvis Presley's 'Love Me Tender'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1956-09-28"), new List<string> { "Elvis_Presley_1/8/1935" }, new List<string>() { GlobalVariables.elvis_presley }, "'Love Me Tender' is a tender ballad by Elvis Presley, expressing heartfelt devotion and romance.");


            new Artist("nicole@editor.com", "Michael", "Jackson", Gender.male, new DateOnly(1958, 8, 29), "Michael Jackson, known as the King of Pop, revolutionized the music industry with his innovative dance moves and groundbreaking music videos.", artistType.singer, new List<string>() { "pop", "R&B" }, new List<string>() { GlobalVariables.michael_jackson });
            new Material("nicole@editor.com", "Michael Jackson's 'Billie Jean'", new List<string>() { "pop" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1982-01-02"), new List<string> { "Michael_Jackson_8/29/1958" }, new List<string>() { GlobalVariables.michael_jackson }, "'Billie Jean' by Michael Jackson is a landmark song in pop music history, known for its distinctive bassline and memorable lyrics.");
            new Material("nicole@editor.com", "Michael Jackson's 'Thriller'", new List<string>() { "pop" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1983-11-30"), new List<string> { "Michael_Jackson_8/29/1958" }, new List<string>() { GlobalVariables.michael_jackson }, "'Thriller' by Michael Jackson is a groundbreaking song and music video that became a cultural phenomenon.");
            new Material("nicole@editor.com", "Michael Jackson's 'Beat It'", new List<string>() { "pop" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1983-02-14"), new List<string> { "Michael_Jackson_8/29/1958" }, new List<string>() { GlobalVariables.michael_jackson }, "'Beat It' by Michael Jackson is a rock-infused pop song known for its high-energy beats and iconic guitar solo by Eddie Van Halen.");
            new Material("nicole@editor.com", "Michael Jackson's 'Smooth Criminal'",new List<string>() { "pop" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1987-10-24"), new List<string> { "Michael_Jackson_8/29/1958" }, new List<string>() { GlobalVariables.michael_jackson }, "'Smooth Criminal' by Michael Jackson is a sleek and dynamic song, featuring his trademark vocal style and innovative dance moves.");
            new Material("nicole@editor.com", "Michael Jackson's 'Man in the Mirror'", new List<string>() { "pop" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1988-01-16"), new List<string> { "Michael_Jackson_8/29/1958" }, new List<string>() { GlobalVariables.michael_jackson }, "'Man in the Mirror' by Michael Jackson is a powerful anthem about personal introspection and social change.");

            new Artist("nicole@editor.com", "Bob", "Dylan", Gender.male, new DateOnly(1941, 5, 24), "Bob Dylan is a seminal figure in folk and rock music, celebrated for his poetic lyrics and influence on the counterculture movement.", artistType.singer, new List<string>() { "folk", "rock" }, new List<string>() { GlobalVariables.bob_dylan });
            new Material("nicole@editor.com", "Bob Dylan's 'Like a Rolling Stone'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1965-07-20"), new List<string> { "Bob_Dylan_5/24/1941" }, new List<string>() { GlobalVariables.bob_dylan }, "'Like a Rolling Stone' is a song by Bob Dylan that revolutionized rock music with its innovative use of electric instruments and introspective lyrics.");
            new Material("nicole@editor.com", "Bob Dylan's 'Blowin' in the Wind'", new List<string>() { "folk" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1963-04-16"), new List<string> { "Bob_Dylan_5/24/1941" }, new List<string>() { GlobalVariables.bob_dylan }, "'Blowin' in the Wind' by Bob Dylan became an anthem of the civil rights movement, known for its poignant lyrics and timeless message.");
            new Material("nicole@editor.com", "Bob Dylan's 'The Times They Are A-Changin'", new List<string>() { "folk" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1964-01-13"), new List<string> { "Bob_Dylan_5/24/1941" }, new List<string>() { GlobalVariables.bob_dylan }, "'The Times They Are A-Changin' by Bob Dylan is a rallying cry for social change and remains relevant in today's world.");
            new Material("nicole@editor.com", "Bob Dylan's 'Knockin' on Heaven's Door'", new List<string>() { "rock" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1973-07-12"), new List<string> { "Bob_Dylan_5/24/1941" }, new List<string>() { GlobalVariables.bob_dylan }, "'Knockin' on Heaven's Door' by Bob Dylan is a soulful song, notable for its haunting melody and reflective lyrics.");
            new Material("nicole@editor.com", "Bob Dylan's 'Mr. Tambourine Man'", new List<string>() { "folk" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1965-04-12"), new List<string> { "Bob_Dylan_5/24/1941" }, new List<string>() { GlobalVariables.bob_dylan }, "'Mr. Tambourine Man' by Bob Dylan is a poetic exploration of the counterculture movement, celebrated for its vivid imagery.");

            new Artist("nicole@editor.com", "Aretha", "Franklin", Gender.female, new DateOnly(1942, 3, 25), "Aretha Franklin, the Queen of Soul, defined an era with her powerful voice and impassioned performances, becoming an icon of American music.", artistType.singer, new List<string>() { "soul", "R&B" }, new List<string>() { GlobalVariables.aretha_franklin });
            new Material("nicole@editor.com", "Aretha Franklin's 'Respect'", new List<string>() { "soul" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1967-04-29"), new List<string> { "Aretha_Franklin_3/25/1942" }, new List<string>() { GlobalVariables.aretha_franklin }, "'Respect' by Aretha Franklin is a powerful anthem of feminism and civil rights, with its soulful vocals and empowering message.");
            new Material("nicole@editor.com", "Aretha Franklin's 'Natural Woman'", new List<string>() { "soul" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1967-09-22"), new List<string> { "Aretha_Franklin_3/25/1942" }, new List<string>() { GlobalVariables.aretha_franklin }, "'Natural Woman' by Aretha Franklin is a soul ballad that celebrates femininity and love, capturing the essence of strength and vulnerability.");
            new Material("nicole@editor.com", "Aretha Franklin's 'Chain of Fools'", new List<string>() { "soul" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1967-11-21"), new List<string> { "Aretha_Franklin_3/25/1942" }, new List<string>() { GlobalVariables.aretha_franklin }, "'Chain of Fools' by Aretha Franklin is a bluesy soul song, known for its powerful vocals and infectious rhythm.");
            new Material("nicole@editor.com", "Aretha Franklin's 'Think'", new List<string>() { "soul" }, DateOnly.FromDateTime(DateTime.Now), DateOnly.Parse("1968-05-02"), new List<string> { "Aretha_Franklin_3/25/1942" }, new List<string>() { GlobalVariables.aretha_franklin }, "'Think' by Aretha Franklin is an empowering anthem about independence and self-confidence, showcasing her incredible vocal range.");
        }
        public void generateArtists()
        {
            new Artist("nicole@editor.com", "John", "Doe", Gender.male, new DateOnly(1985, 7, 15), "John Doe is a versatile jazz singer known for his smooth vocals and improvisational skills.", artistType.singer, new List<string>() { "jazz" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Jane", "Smith", Gender.female, new DateOnly(1990, 3, 22), "Jane Smith is a prolific songwriter in the rock Genre, blending heartfelt lyrics with powerful melodies.", artistType.songWriter, new List<string>() { "rock" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Michael", "Johnson", Gender.male, new DateOnly(1982, 9, 5), "Michael Johnson is a conductor renowned for his precise interpretations and dynamic performances with orchestras worldwide.", artistType.conductor, new List<string>() { "classical" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Emily", "Davis", Gender.female, new DateOnly(1987, 12, 10), "Emily Davis is an acclaimed instrumentalist, known for her virtuosity on the violin and her innovative approach to classical and contemporary music.", artistType.instrumentalist, new List<string>() { "classical", "hiphop" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "David", "Brown", Gender.male, new DateOnly(1978, 5, 3), "David Brown is a versatile composer, celebrated for his film scores that capture the emotional depth of each scene with intricate orchestrations and memorable themes.", artistType.composer, new List<string>() { "country" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Sarah", "Garcia", Gender.female, new DateOnly(1989, 11, 18), "Sarah Garcia is a talented producer known for her innovative sound design and ability to create chart-topping hits across various genres.", artistType.producer, new List<string>() { "pop", "blues" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Alex", "Martinez", Gender.male, new DateOnly(1983, 2, 28), "Alex Martinez is a renowned DJ recognized for his electrifying performances and seamless mixes that keep audiences dancing all night long.", artistType.dj, new List<string>() { "electronic" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Jessica", "Robinson", Gender.female, new DateOnly(1984, 8, 7), "Jessica Robinson is a trailblazing rapper known for her empowering lyrics and fierce delivery, addressing social issues and inspiring change through her music.", artistType.rapper, new List<string>() { "hiphop", "rap" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Mark", "Wilson", Gender.male, new DateOnly(1981, 10, 12), "Mark Wilson is an influential singer-songwriter known for his introspective lyrics and soulful voice, touching hearts with his heartfelt ballads and anthems.", artistType.songWriter, new List<string>() { "folk", "rnb" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            new Artist("nicole@editor.com", "Rachel", "Lee", Gender.female, new DateOnly(1986, 6, 25), "Rachel Lee is a dynamic instrumentalist mastering multiple instruments and genres, from classical violin to jazz piano, pushing boundaries and redefining musical versatility.", artistType.instrumentalist, new List<string>() { "classical", "jazz" }, new List<string>() { GlobalVariables.img1, GlobalVariables.img3 });
            
        }
        public void emptyall()
        {
        
            new Dao<User>(GlobalVariables.usersFile).WriteDictionaryToFile(new Dictionary<string, User>());
            new Dao<Editor>(GlobalVariables.editorsFile).WriteDictionaryToFile(new Dictionary<string, Editor>());
            new Dao<Member>(GlobalVariables.membersFile).WriteDictionaryToFile(new Dictionary<string, Member>());
            new Dao<Artist>(GlobalVariables.artistsFile).WriteDictionaryToFile(new Dictionary<string, Artist>());
            new Dao<Text>(GlobalVariables.textsFile).WriteDictionaryToFile(new Dictionary<string, Text>());
            new Dao<Material>(GlobalVariables.materialsFile).WriteDictionaryToFile(new Dictionary<string, Material>());
            new Dao<Group>(GlobalVariables.groupsFile).WriteDictionaryToFile(new Dictionary<string, Group>());
            new Dao<Album>(GlobalVariables.albumsFile).WriteDictionaryToFile(new Dictionary<string, Album>());
            new Dao<Genre>(GlobalVariables.genresFile).WriteDictionaryToFile(new Dictionary<string, Genre>());
        }
    }
}
