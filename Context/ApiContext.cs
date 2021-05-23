using Microsoft.EntityFrameworkCore;
using twitter_clone.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace twitter_clone.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
          : base(options)
        {}


        public DbSet<User> Users { get; set; }
        
    }
}