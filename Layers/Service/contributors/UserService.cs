using muzickiKatalog.Layers.Model.contributors;
using muzickiKatalog.Layers.Repository.contributors;

namespace muzickiKatalog.Layers.Service.contributors
{
    public class UserService
    {
        public static IEnumerable<User> GetAll() => UserRepository.getAll().Values;
    }
}
