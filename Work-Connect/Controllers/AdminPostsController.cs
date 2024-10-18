using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Work_Connect.Controllers
{
    public class AdminPostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AdminPostsController> _logger;

        public AdminPostsController(ApplicationDbContext context, ILogger<AdminPostsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> adminPosts()
        {
            var waitingJobs = await _context.WaitingJobs.ToListAsync();
            return View(waitingJobs);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            _logger.LogInformation("Approving job with ID: {id}", id);

            // Fetch job from WaitingJob table
            var waitingJob = await _context.WaitingJobs.FindAsync(id);
            if (waitingJob != null)
            {
                try
                {
                    // Create a new job object for the PostAJob table (excluding JobId)
                    var postJob = new postAJob
                    {
                        JobTitle = waitingJob.JobTitle,
                        CompanyName = waitingJob.CompanyName,
                        JobDescription = waitingJob.JobDescription,
                        MinSalary = waitingJob.MinSalary,
                        MaxSalary = waitingJob.MaxSalary,
                        JobCategory = waitingJob.JobCategory,
                        JobType = waitingJob.JobType,
                        CreatedAt = waitingJob.CreatedAt
                    };

                    // Add the job to the PostAJob table
                    _context.postAJob.Add(postJob);

                    // Remove the job from the WaitingJob table
                    _context.WaitingJobs.Remove(waitingJob);

                    // Save changes asynchronously
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Job approved successfully.";
                    _logger.LogInformation("Job with ID: {id} approved and moved to PostAJob.", id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error approving job with ID: {id}", id);
                    TempData["Error"] = "An error occurred while approving the job.";
                }
            }
            else
            {
                TempData["Error"] = "Job not found.";
                _logger.LogWarning("Job with ID: {id} not found.", id);
            }

            return RedirectToAction(nameof(adminPosts));
        }

        // Existing Remove method for deletion
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var job = await _context.WaitingJobs.FindAsync(id);
            if (job != null)
            {
                _context.WaitingJobs.Remove(job);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Job deleted successfully.";
            }
            else
            {
                TempData["Error"] = "Job not found.";
            }
            return RedirectToAction(nameof(adminPosts));
        }
    }
}
