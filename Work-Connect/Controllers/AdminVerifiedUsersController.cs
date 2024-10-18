using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class AdminVerifiedUsersController : Controller
    {
        private readonly ApplicationDbContext _context; // Database context

        // Constructor to inject the ApplicationDbContext
        public AdminVerifiedUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminVerifiedUsers
        public async Task<IActionResult> AdminVerifiedUsers()
        {
            // Retrieve the list of verified users from the database
            List<VerifiedUsers> verifiedUsers = await _context.VerifiedUsers.ToListAsync();
            return View(verifiedUsers); // Return the list to the view
        }

        // GET: AdminVerifiedUsers/Adduser
        public IActionResult Adduser()
        {
            return View(new VerifiedUsers()); // Return a new VerifiedUsers model for the view
        }

        // POST: AdminVerifiedUsers/Adduser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adduser(VerifiedUsers verifiedUsers)
        {
            if (ModelState.IsValid) // Check if the model state is valid
            {
                _context.VerifiedUsers.Add(verifiedUsers); // Add the new user to the context
                await _context.SaveChangesAsync(); // Save changes to the database
                return RedirectToAction(nameof(AdminVerifiedUsers)); // Redirect to the list
            }
            return View(verifiedUsers); // Return the view with the model if validation fails
        }

        // GET: AdminVerifiedUsers/Edituser/{id}
        public async Task<IActionResult> Edituser(int id)
        {
            // Find the user by ID
            var verifiedUser = await _context.VerifiedUsers.FindAsync(id);
            if (verifiedUser == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(verifiedUser); // Return the edit view with the user data
        }

        // POST: AdminVerifiedUsers/Edituser/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edituser(int id, VerifiedUsers model)
        {
            if (id != model.Id) // Check if the ID matches
            {
                return NotFound(); // Return 404 if the ID does not match
            }

            if (ModelState.IsValid) // Check if the model state is valid
            {
                try
                {
                    _context.Update(model); // Update the user in the context
                    await _context.SaveChangesAsync(); // Save changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerifiedUsersExists(model.Id))
                    {
                        return NotFound(); // Return 404 if the user does not exist
                    }
                    else
                    {
                        throw; // Rethrow the exception if it's not a concurrency issue
                    }
                }
                return RedirectToAction(nameof(AdminVerifiedUsers)); // Redirect to the list
            }
            return View(model); // Return the view with the model if validation fails
        }

        // POST: AdminVerifiedUsers/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Find the user by ID
            var verifiedUser = await _context.VerifiedUsers.FindAsync(id);
            if (verifiedUser == null)
            {
                return NotFound(); // Return 404 if not found
            }

            _context.VerifiedUsers.Remove(verifiedUser); // Remove the user from the context
            await _context.SaveChangesAsync(); // Save changes to the database

            return RedirectToAction(nameof(AdminVerifiedUsers)); // Redirect to the list
        }

        // Check if the user exists
        private bool VerifiedUsersExists(int id)
        {
            return _context.VerifiedUsers.Any(e => e.Id == id); // Check if the user exists in the database
        }

    }
}
