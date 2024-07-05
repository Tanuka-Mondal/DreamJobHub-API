using FavouriteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FavouriteAPI.Context
{

    public class FavouriteDbContext : DbContext
    {
        public FavouriteDbContext(DbContextOptions<FavouriteDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Job>().HasKey(j => j.Id);

        }

    }
}
