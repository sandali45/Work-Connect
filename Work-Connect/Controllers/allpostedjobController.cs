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
        public async Task<IActionResult> Delete(int id)
        {
            var jobPost = await _context.postAJob.FindAsync(id); // Find the job post by ID
            if (jobPost == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.postAJob.Remove(jobPost); // Remove the job post
            await _context.SaveChangesAsync(); // Save changes to the database

            return Json(new { success = true }); // Return success as JSON
        }
    }
}
