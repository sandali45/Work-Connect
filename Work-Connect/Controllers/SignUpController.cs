using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Work_Connect.Models;
using Work_Connect.Helpers;
using Work_Connect.Data; // Add the correct namespace for ApplicationDbContext

public class SignUpController : Controller
{
    private readonly ApplicationDbContext _context;

    // Constructor to inject the database context
    public SignUpController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(string name, string email, string password)
    {
        // Check if a user with the same email already exists in the database
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
        if (existingUser != null)
        {
            ViewBag.ErrorMessage = "User with this email already exists.";
            return View();
        }

        // Hash the password before saving it to the database
        var hashedPassword = PasswordHelper.HashPassword(password);

        // Create a new user object
        var newUser = new User
        {
            Name = name,
            Email = email,
            Password = hashedPassword
        };

        // Add the new user to the Users table in the database
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync(); // Save changes asynchronously

        // Redirect to the home page after a successful signup
        return RedirectToAction("Index", "Home");
    }
}
