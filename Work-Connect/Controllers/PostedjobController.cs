using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore;

namespace Work_Connect.Controllers
{
    public class PostedjobController : Controller
    {
        private readonly ApplicationDbContext _context; // Make sure to create this context


        public PostedjobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PostedJobHtml()
        {
            List<postAJob> jobPosts = await _context.postAJob.ToListAsync();
            return View(jobPosts);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var jobPost = await _context.postAJob.FindAsync(id);
            if (jobPost != null)
            {
                _context.postAJob.Remove(jobPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("PostedJobHtml");
        }




    }
}

