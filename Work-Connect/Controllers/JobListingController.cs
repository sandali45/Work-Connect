using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore;

public class JobListingController : Controller
{

    private readonly ApplicationDbContext _context; // Make sure to create this context

    public JobListingController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> JobListing()
    {
        List<postAJob> jobPosts = await _context.postAJob.ToListAsync();
        return View(jobPosts);
    }
}
