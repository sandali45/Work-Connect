using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Work_Connect.Models; 
using Work_Connect.Data; 

public class JobListingController : Controller
{
    private readonly ApplicationDbContext _context; 

    public JobListingController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Retrieve job listings from the database
        List<Job> jobs = _context.Jobs.ToList(); //DbSet<Job> in the DbContext
        return View(jobs); // Pass the list of jobs to the view
    }
}
