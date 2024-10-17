using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class AdminVerifiedcompanies : Controller
    {
        private readonly ApplicationDbContext _context; // Make sure to create this context

        public AdminVerifiedcompanies(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AdminVerifiedcompanie()
        {
            List<VerifiedCompany> VerifiedCompany = await _context.VerifiedCompany.ToListAsync();
            return View(VerifiedCompany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the company by ID
            var verifiedCompany = await _context.VerifiedCompany.FindAsync(id);
            if (verifiedCompany == null)
            {
                return NotFound(); // Return 404 if not found
            }

            // Remove the company from the context
            _context.VerifiedCompany.Remove(verifiedCompany);
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction(nameof(AdminVerifiedcompanie)); // Redirect back to the list
        }


    }
}
