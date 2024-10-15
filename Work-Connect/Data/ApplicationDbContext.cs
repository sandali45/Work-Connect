using Microsoft.EntityFrameworkCore;
using Work_Connect.Models; 
namespace Work_Connect.Data 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<postAJob> postAJob { get; set; } 

    }
}
