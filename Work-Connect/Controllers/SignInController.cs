using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Work_Connect.Data;
using Work_Connect.Models;  // Import your User model and context
using Work_Connect.Helpers;

namespace Work_Connect.Controllers
{
    public class SignInController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SignInController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SignIn
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        // POST: SignIn
        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            // Check if user is admin by hardcoding admin credentials
            if (email == "adminuser@gmail.com" && password == "admin1")
            {
                // Redirect to the Admin Panel
                return RedirectToAction("Index", "AdminUsers");
            }

            // Check if the user exists in the database (non-admin)
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                // User with this email doesn't exist
                ViewBag.ErrorMessage = "Email not registered. Please sign up.";
                return View();
            }

            // Check if the entered password matches the hashed password in the database
            if (!PasswordHelper.VerifyPassword(password, user.Password))
            {
                // Password is incorrect
                ViewBag.ErrorMessage = "Invalid Email or Password.";
                return View();
            }

            // Regular user is authenticated, redirect to user dashboard or homepage
            return RedirectToAction("Index", "Home");
        }
    }
}
