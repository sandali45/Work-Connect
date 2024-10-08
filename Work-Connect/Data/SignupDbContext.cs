using Microsoft.EntityFrameworkCore;
using Work_Connect.Models;

public class SignupDbContext : DbContext
{
    public SignupDbContext(DbContextOptions<SignupDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }  
}
