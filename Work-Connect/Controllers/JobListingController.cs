using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

public class JobListingController : Controller
{
    private readonly ApplicationDbContext _context; // Your database context

    public JobListingController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: JobListing
    public async Task<IActionResult> JobListing()
    {
        // Fetch all job posts from the database
        List<postAJob> jobPosts = await _context.postAJob.ToListAsync();
        return View(jobPosts); // Return the job posts to the view
    }

    // Submit Application Action (Handle POST request)
    [HttpPost]
    public async Task<IActionResult> SubmitApplication([FromBody] ApplicationData application)
    {
        if (application == null || string.IsNullOrEmpty(application.ApplicantName) || string.IsNullOrEmpty(application.Resume))
        {
            // Return bad request if the applicant name or resume is missing
            return BadRequest(new { success = false, message = "Invalid data. Name and Resume are required." });
        }

        try
        {
            // Decode the Base64-encoded resume data
            var resumeBytes = Convert.FromBase64String(application.Resume);

            // Optional: Save the resume to a file or database
            // For example, saving to a file:
            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes", $"{application.ApplicantName}_Resume_{DateTime.Now.Ticks}.pdf");

            await System.IO.File.WriteAllBytesAsync(savePath, resumeBytes);

            // Optional: You can store the file path in the database if needed, along with the applicant's data

            // Assuming you want to save application info in the database, you can use JobService for that purpose
            // e.g., _jobService.SaveApplication(applicantName, resumeFilePath);

            return Ok(new { success = true, message = "Application submitted successfully!" });
        }
        catch (FormatException)
        {
            // Return bad request if the resume format is invalid (Base64 decoding fails)
            return BadRequest(new { success = false, message = "Invalid resume format." });
        }
        catch (Exception ex)
        {
            // Catch any other exceptions and return a generic error message
            return StatusCode(500, new { success = false, message = $"An error occurred: {ex.Message}" });
        }
    }
}

// Model to capture application data
public class ApplicationData
{
    public string JobID { get; set; }
    public string ApplicantName { get; set; }
    public string Resume { get; set; } // Base64-encoded resume data


}
