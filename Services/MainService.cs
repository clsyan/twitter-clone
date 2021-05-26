using System.Threading.Tasks;
using twitter_clone.Models;
using System.Collections.Generic;
using twitter_clone.Context;
using Microsoft.EntityFrameworkCore;
using twitter_clone.Interfaces;
using System.Linq;
using System;

namespace twitter_clone.Services {

    
    public class MainService : IMainService {
        private readonly ApiContext _context;
        public MainService(ApiContext context)
        {
            _context = context;
        }

        async public Task<List<User>> GetUsers() {
            return await _context.Users.ToListAsync<User>();
        }
        async public Task<User> CreateUser(User user) {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;  
        } 
        async public Task<User> UserExists(User user) {
            return await _context.Users.FindAsync(user.At, user.Email);
        }
        async public Task DeleteUser(User user) {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        async public Task<bool> Authenticate(User credentials) {
            var user = await (from u in _context.Users where u.Email == credentials.Email select u).SingleAsync();
            if(user == null) return false;
            return BCrypt.Net.BCrypt.Verify(credentials.Password, user.Password);

        }

        async public Task<User[]> Follow(User[] users) {
            
            var follower = await _context.Users.FindAsync(users[0].At, users[0].Email);
            var following = await _context.Users.FindAsync(users[1].At, users[1].Email);
            _context.Users.Attach(follower);
            _context.Entry(follower).State = EntityState.Modified;
            _context.Users.Attach(following);
            _context.Entry(following).State = EntityState.Modified;

            if(follower.Following.Contains(following)) {
                _context.Users.Update(follower);
                _context.Users.Update(following);
                follower.Following.Remove(following);
                following.Followers.Remove(follower);
            } else {
                _context.Users.Update(follower);
                _context.Users.Update(following);
                follower.Following.Add(following);
                following.Followers.Add(follower);
            }

            await _context.SaveChangesAsync();
            return new User[]{follower, following};
            
        }
        async public Task<List<User>> GetFollowers(User user) {
            var u = await _context.Users.FindAsync(user.At, user.Email);

            return u.Followers;
        }

        async public Task<List<User>> GetFollowing(User user) {
            return (await _context.Users.FindAsync(user.At, user.Email)).Following;
        }
    }
} 