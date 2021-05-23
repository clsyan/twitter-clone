using System.Threading.Tasks;
using twitter_clone.Models;
using System.Collections.Generic;
using twitter_clone.Context;
using Microsoft.EntityFrameworkCore;
using twitter_clone.Interfaces;

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
    }
} 