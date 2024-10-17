using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class AdminLoginController : Controller

    {
		// GET: AdminLogin
		[HttpGet]
		public IActionResult AdminLogin()
		{
			return View();
		}
		private readonly ApplicationDbContext _context; // Make sure to create this context

		public AdminLoginController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public IActionResult Login(Admins model)
		{
			if (ModelState.IsValid)
			{
				// Check if the username and password exist in the database
				var admin = _context.Admins
					.FirstOrDefault(a => a.Username == model.Username && a.Password == model.Password);

				if (admin != null)
				{
					// Credentials are valid, redirect to the admin home page
					return RedirectToAction("adminhome", "adminhome");
				}
				else
				{
					// Invalid credentials, show error message
					ViewBag.ErrorMessage = "Invalid Username or Password";
					return View("AdminLogin", model); // Stay on the login page
				}
			}

			return View(model);
		}

		// GET: Login page
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

	}
}
