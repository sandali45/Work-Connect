using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Work_Connect.Models;
using Work_Connect.Helpers;  

public class SignUpController : Controller
{
    private readonly SignupDbContext _context;  

    public SignUpController(SignupDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(string name, string email, string password)
    {
        // Server-side email validation
        if (!email.Contains("@") || !email.Contains("."))
        {
            ViewBag.ErrorMessage = "Please enter a valid email address.";
            return View();
        }

        // Server-side password validation (exactly 6 characters)
        if (password.Length != 6)
        {
            ViewBag.ErrorMessage = "Password must be exactly 6 characters long.";
            return View();
        }

        // Check if the user already exists by email
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
        if (existingUser != null)
        {
            ViewBag.ErrorMessage = "User with this email already exists. Please try logging in or reset your password.";
            return View();
        }

        // Hash the password before saving
        string hashedPassword = PasswordHelper.HashPassword(password);

        // Create a new user
        var newUser = new User
        {
            Name = name,
            Email = email,
            Password = hashedPassword  // Save hashed password
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();  // Save the new user to the database

        ViewBag.SuccessMessage = "User created successfully!";
        return View();
    }
}
