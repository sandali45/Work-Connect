using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class allapliedjobController : Controller
    {
        private readonly ApplicationDbContext _context; // Make sure to create this context

        public allapliedjobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> allapliedjob()
        {
            List<JobApplication> JobApplication = await _context.JobApplications.ToListAsync();
            return View(JobApplication);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            // Find the company by ID
            var JobApplication = await _context.JobApplications.FindAsync(id);
            if (JobApplication == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Remove the company from the context
            _context.JobApplications.Remove(JobApplication);
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction(nameof(allapliedjob)); // Redirect back to the list
        }

    }
}
