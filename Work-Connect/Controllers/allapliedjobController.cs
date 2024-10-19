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
            List<Usersappliedjob> Usersappliedjob = await _context.Usersappliedjob.ToListAsync();
            return View(Usersappliedjob);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            // Find the company by ID
            var Usersappliedjob = await _context.Usersappliedjob.FindAsync(id);
            if (Usersappliedjob == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Remove the company from the context
            _context.Usersappliedjob.Remove(Usersappliedjob);
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction(nameof(allapliedjob)); // Redirect back to the list
        }

    }
}
