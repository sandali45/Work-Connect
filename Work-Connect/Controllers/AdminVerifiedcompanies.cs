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

        public async Task<IActionResult> Edit(int id)
        {
            // Find the verified company by ID
            var verifiedCompany = await _context.VerifiedCompany.FindAsync(id);
            if (verifiedCompany == null)
            {
                return NotFound(); // Return 404 if not found
            }

            return View(verifiedCompany); // Return the edit view with the company data
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VerifiedCompany model)
        {
            if (id != model.companyId)
            {
                return NotFound(); // Return 404 if the ID does not match
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model); // Update the company in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerifiedCompanyExists(model.companyId))
                    {
                        return NotFound(); // Return 404 if the company does not exist
                    }
                    else
                    {
                        throw; // Rethrow the exception if it's not a concurrency issue
                    }
                }

                return RedirectToAction(nameof(AdminVerifiedcompanie)); // Redirect back to the list
            }

            return View(model); // Return the edit view with the model if the model state is not valid
        }

        // Check if the company exists
        private bool VerifiedCompanyExists(int id)
        {
            return _context.VerifiedCompany.Any(e => e.companyId == id);
        }

        // GET: AdminVerifiedcompanies/Add
        // GET: Add New Company Page
        public IActionResult Add()
        {
            return View(new VerifiedCompany());
        }

        // POST: Add New Company
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VerifiedCompany company)
        {
            if (ModelState.IsValid)
            {
                _context.VerifiedCompany.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AdminVerifiedcompanie));
            }
            return View(company); // Return the view with the model to show validation errors
        }

    }
}
