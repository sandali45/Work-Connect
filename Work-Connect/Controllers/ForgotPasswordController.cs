using Microsoft.AspNetCore.Mvc;
using Work_Connect.Models;
using System.Linq;
using System.Threading.Tasks;

public class ForgotPasswordController : Controller
{
    private readonly SignupDbContext _context;

    public ForgotPasswordController(SignupDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(string email, string newPassword)
    {
        // Check if the user exists by email
        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
        {
            return BadRequest("User with this email does not exist.");
        }

        // Update the user's password
        user.Password = newPassword;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();  // Save the new password in the database

        return Ok("Password updated successfully.");
    }
}
