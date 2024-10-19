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

        
        public DbSet<User> Users { get; set; }
        public DbSet<postAJob> postAJob { get; set; }
        public DbSet<VerifiedCompany> VerifiedCompany { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<WaitingJob> WaitingJobs { get; set; }
     
        public DbSet<VerifiedUsers> VerifiedUsers { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<InterviewSchedule> InterviewSchedules { get; set; }

    }
}
