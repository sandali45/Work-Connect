using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var waitingJob = await _context.WaitingJobs.FindAsync(id);
            if (waitingJob != null)
            {
                try
                {
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

                    _context.postAJob.Add(postJob);
                    _context.WaitingJobs.Remove(waitingJob);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "Job approved successfully.";
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
            }

            return RedirectToAction(nameof(adminPosts));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var job = await _context.WaitingJobs.FindAsync(id);
            if (job == null)
            {
                TempData["Error"] = "Job not found.";
                return NotFound();
            }

            _context.WaitingJobs.Remove(job);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Job deleted successfully.";

            return RedirectToAction(nameof(adminPosts));
        }

        // GET: AdminPosts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var job = await _context.WaitingJobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: AdminPosts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobTitle,CompanyName,JobDescription,MinSalary,MaxSalary,JobCategory,JobType")] WaitingJob job)
        {
            if (id != job.JobId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the CreatedAt field to the current date and time
                    job.CreatedAt = DateTime.Now;  // Ensure valid date for CreatedAt

                    _context.Update(job);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Job details updated successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaitingJobExists(job.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(adminPosts));
            }
            return View(job);
        }

        private bool WaitingJobExists(int id)
        {
            return _context.WaitingJobs.Any(e => e.JobId == id);
        }
    }
}
