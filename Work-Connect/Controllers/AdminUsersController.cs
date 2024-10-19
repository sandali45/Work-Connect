using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _context; // Make sure to create this context

        public AdminUsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AdminUsers()
        {
            List<User> User = await _context.Users.ToListAsync();
            return View(User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            // Log incoming ID
            Console.WriteLine($"Attempting to delete user with ID: {id}");

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            Console.WriteLine("User deleted successfully.");
            return RedirectToAction(nameof(AdminUsers));
        }

    }
}


     