using System.Collections.Generic;
using twitter_clone.Models;
using System.Threading.Tasks;

namespace twitter_clone.Interfaces
{
    public interface IMainService {
        Task<List<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task<bool> UserExists(User user);
    }
}