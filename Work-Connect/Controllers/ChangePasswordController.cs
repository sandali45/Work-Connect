using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Work_Connect.Helpers;

namespace Work_Connect.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChangePasswordController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChangePassword
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: ChangePassword
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            // Get UserId from the cookie
            string userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction("SignIn", "SignIn");
            }
            int userId = int.Parse(userIdCookie);

            // Fetch the user from the database
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Check if the current password is correct
            if (!PasswordHelper.VerifyPassword(currentPassword, user.Password))
            {
                ModelState.AddModelError("", "Current password is incorrect.");
                return View();
            }

            // Check if new password and confirm password match
            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "New password and confirm password do not match.");
                return View();
            }

            // Update the user's password
            user.Password = PasswordHelper.HashPassword(newPassword); // Ensure you hash the new password
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Password changed successfully.";
            return RedirectToAction("Profile", "Profile");
        }
    }
}
