using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Work_Connect.Models;  // Import your User model
using Work_Connect.Data;     // Import your ApplicationDbContext
using Work_Connect.Helpers;  // Import PasswordHelper for hashing

namespace Work_Connect.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForgotPasswordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET method for Forgot Password page
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // POST method for handling password reset
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email, string newPassword)
        {
            // Check if the user exists by email
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                // User with this email does not exist
                TempData["ErrorMessage"] = "The email you entered is not registered. Please check and try again.";
                return RedirectToAction("ForgotPassword"); // Reload the form with error
            }

            // If the user exists, update the password (with hashing)
            user.Password = PasswordHelper.HashPassword(newPassword);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            // Set success message
            TempData["SuccessMessage"] = "Password updated successfully.";
            return RedirectToAction("ForgotPassword");
        }
    }
}
