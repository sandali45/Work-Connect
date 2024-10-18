using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore; 

namespace Work_Connect.Controllers
{
    public class allpostedjobController : Controller
    {
     
        private readonly ApplicationDbContext _context; // Make sure to create this context

        public allpostedjobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> allpostedjob()
        {
            List<postAJob> jobPosts = await _context.postAJob.ToListAsync();
            return View(jobPosts);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the job by ID
            var job = await _context.postAJob.FindAsync(id);
            if (job == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Remove the job from the context
            _context.postAJob.Remove(job);
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction(nameof(allpostedjob)); // Redirect back to the list
        }
    }
    }
