using System.Collections.Generic;
using twitter_clone.Models;
using System.Threading.Tasks;

namespace twitter_clone.Interfaces
{
    public interface IMainService {
        Task<List<User>> GetUsers();
        Task<User> CreateUser(User user);
        Task DeleteUser(User user);
        Task<User> UserExists(User user);
        Task<bool> Authenticate(User credentials);
        Task<User[]> Follow(User[] users);
        Task<List<User>> GetFollowing(User user);
        Task<List<User>> GetFollowers(User user);
    }
}