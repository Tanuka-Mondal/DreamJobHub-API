using JobAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobAPI.Context
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Job> Jobs { get; set; }
    }
}
