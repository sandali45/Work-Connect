using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class AdminLoginController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AdminLoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AdminLogin
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View(new Admins());  // Renders the login form
        }

        // POST: AdminLogin/Login
        [HttpPost]
        public IActionResult Login(Admins model)
        {
            if (ModelState.IsValid)
            {
                // Validate the admin's credentials from the database
                var admin = _context.Admins
                    .FirstOrDefault(a => a.Username == model.Username && a.Password == model.Password);

                if (admin != null)
                {
                    // If the credentials are valid, redirect to the admin home page
                    return RedirectToAction("adminhome", "adminhome");
                }
                else
                {
                    // If the credentials are invalid, show an error message
                    ViewBag.ErrorMessage = "Invalid Username or Password";
                    return View("AdminLogin", model);  // Return to login page with error message
                }
            }

            // If the model state is not valid, return the same view
            return View("AdminLogin", model);
        }
    

        }
}
