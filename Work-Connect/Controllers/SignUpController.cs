using Microsoft.AspNetCore.Mvc;
using Work_Connect.Models;
using System.Linq;
using System.Threading.Tasks;

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
    public async Task<IActionResult> SignUp(string name, string email, string password)
    {
        // Check if the user already exists by email
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == email);
        if (existingUser != null)
        {
            return BadRequest("User with this email already exists.");
        }

        // Create a new user
        var newUser = new User
        {
            Name = name,
            Email = email,
            Password = password
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();  // Save the new user to the database

        return Ok("User created successfully.");
    }
}
