using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Work_Connect.Models;
using Work_Connect.Services;

public class JobsController : Controller
{
    private readonly JobService _jobService;

    public JobsController(JobService jobService)
    {
        _jobService = jobService;
    }

    // Add a method to handle search requests
    [HttpGet]
    public async Task<IActionResult> Search(string searchQuery)
    {
        var jobs = await _jobService.SearchJobsBySkills(searchQuery);
        return View("Search", jobs); // Return the jobs to the view
    }
}


