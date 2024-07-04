using muzickiKatalog.Layers.dao;
using muzickiKatalog.Layers.Model.contributors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace muzickiKatalog.Layers.Repository.contributors
{
    public class MemberRepository
    {
        public static Dictionary<string, Member> getAll()
        {
            return new Dao<Member>(GlobalVariables.membersFile).ReadDictionaryFromFile();
        }
        public static void save(Member member)
        {
            SaveOneInstance<Member>.SaveOneInstanceInDictionary(member, member.username, GlobalVariables.membersFile);
        }
    }
}
