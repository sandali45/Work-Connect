using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using System.Threading.Tasks;

namespace Work_Connect.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method to load the user list
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // POST method to handle the deletion of a user
        [HttpPost]
        [ValidateAntiForgeryToken] // To ensure anti-forgery validation
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                TempData["Error"] = "User not found.";
                return RedirectToAction("Index");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "User deleted successfully.";
            return RedirectToAction("Index");
        }

    }
}
