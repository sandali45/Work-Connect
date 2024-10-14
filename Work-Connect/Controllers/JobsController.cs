using Microsoft.AspNetCore.Mvc;
using Work_Connect.Services;

namespace Work_Connect.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;

        public JobsController(JobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<IActionResult> Search(string searchQuery)
        {
            var jobs = await _jobService.SearchJobsBySkills(searchQuery);
            ViewData["searchQuery"] = searchQuery; // Set the search query for the view
            return View("Search", jobs); // Return the search results to the Search view
        }
    }
}
