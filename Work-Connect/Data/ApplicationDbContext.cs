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
        public DbSet<post_a_job> post_a_job { get; set; } // Maps to the post_a_job table
    }
}
