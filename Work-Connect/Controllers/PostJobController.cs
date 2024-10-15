using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore;

namespace Work_Connect.Controllers
{
    public class PostJobController : Controller
    {
      
        private readonly ApplicationDbContext _context; // Make sure to create this context

        public PostJobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> postJob()
        {
            List<postAJob> jobPosts = await _context.postAJob.ToListAsync();
            return View(jobPosts);
        }
        [HttpPost]
       
        public IActionResult waitingForApproval()
        {
            return View();
        }
    }
}
