using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;
using Work_Connect.Models;

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
        [HttpPost]
        public async Task<IActionResult> ScheduleInterview(InterviewSchedule interviewSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.InterviewSchedules.Add(interviewSchedule);
                await _context.SaveChangesAsync(); // Save the interview schedule to the database
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Invalid data." });
        }

    }
}
