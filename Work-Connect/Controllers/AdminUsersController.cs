using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore;

namespace Work_Connect.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly SignupDbContext _context;

        public AdminUsersController(SignupDbContext context)
        {
            _context = context;
        }

        // GET: AdminUsers/Index - Fetch users and pass them to the view
        public IActionResult Index()
        {
            var users = _context.Users.ToList();  // Fetch all users from the DB
            return View(users);  // Pass users list to the view
        }

        // POST: AdminUsers/Delete - Delete user by ID
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);  // Find user by ID
            if (user != null)
            {
                _context.Users.Remove(user);  // Remove the user from DB
                await _context.SaveChangesAsync();  // Save changes in Azure SQL Database
                TempData["Message"] = "User deleted successfully!";
            }
            else
            {
                TempData["Error"] = "User not found!";
            }
            return RedirectToAction(nameof(Index));  // Redirect back to the users list page
        }
    }
}
