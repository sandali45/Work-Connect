using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;

namespace Work_Connect.Controllers
{
    public class allappliedcandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public allappliedcandidatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> allappliedcandidates()
        {
            var applications = await _context.JobApplications.ToListAsync(); // Fetch job applications
            return View(applications); // Pass the list to the view
        }

        public IActionResult DownloadResume(int applicationId)
        {
            var application = _context.JobApplications.Find(applicationId);
            if (application == null || string.IsNullOrEmpty(application.Resume))
            {
                return NotFound();
            }

            var resumeBytes = Convert.FromBase64String(application.Resume);
            return File(resumeBytes, "application/pdf", $"{application.ApplicantName}_Resume.pdf"); // Change MIME type if needed
        }

    }
}
