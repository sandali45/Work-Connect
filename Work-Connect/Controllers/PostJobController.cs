using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using System;
using System.Threading.Tasks;

namespace Work_Connect.Controllers
{
    public class PostJobController : Controller
    {
        private readonly ApplicationDbContext _context;
        private static Random random = new Random();

        public PostJobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult waitingForApproval()
        {
            return View();
        }

        // Method to generate a random string for JobId
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet]
        public IActionResult PostJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostJob(string JobTitle, string CompanyName, string JobDescription, decimal MinSalary, decimal MaxSalary, string JobCategory, string JobType)
        {
            // Validate if required fields are provided
            if (string.IsNullOrEmpty(JobTitle) || string.IsNullOrEmpty(CompanyName) || string.IsNullOrEmpty(JobDescription) || MinSalary <= 0 || MaxSalary <= 0)
            {
                ViewBag.ErrorMessage = "All fields are required and salaries must be positive numbers.";
                return View();
            }

            // Create a new Job object
            var job = new WaitingJob
            {
                //JobId = int.Parse(RandomString(3)), // Generate random JobId
                JobTitle = JobTitle,
                CompanyName = CompanyName,
                JobDescription = JobDescription,
                MinSalary = MinSalary,
                MaxSalary = MaxSalary,
                JobCategory = JobCategory,
                JobType = JobType,
                CreatedAt = DateTime.Now // Set current date and time
            };

            // Add the new job to the Jobs table in the database
            _context.WaitingJobs.Add(job);
            await _context.SaveChangesAsync(); // Save changes asynchronously

            return RedirectToAction("waitingForApproval", "PostJob");
        }
    }
}
