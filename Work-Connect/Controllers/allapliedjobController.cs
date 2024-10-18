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

    }
}
