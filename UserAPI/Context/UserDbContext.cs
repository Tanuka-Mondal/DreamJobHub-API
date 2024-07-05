using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserAPI.Models;

namespace UserAPI.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
    }
}
