using System.Threading.Tasks;
using DatingApp.Models;

namespace DatingApp.Data
{
    public interface IAuthRepository
    {
         Task<User> RegisterAsync(User user, string password);
         Task<User> LoginAsync(string username, string password);
         Task<bool> IsUserExistAsync(string username);
    }
}