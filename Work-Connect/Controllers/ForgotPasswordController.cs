using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ForgotPasswordController : Controller
{
    // Temporarily remove or comment out the `SignupDbContext` dependency
    // private readonly SignupDbContext _context;

    // Comment out the constructor that injects `SignupDbContext`
    // public ForgotPasswordController(SignupDbContext context)
    // {
    //     _context = context;
    // }

    // This method handles the GET request to display the ForgotPassword form
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();  // This will return the ForgotPassword.cshtml view located in Views/ForgotPassword
    }

    // You can comment out the POST method for now if you're just testing the view
    // [HttpPost]
    // public async Task<IActionResult> ForgotPassword(string email, string newPassword)
    // {
    //     return Ok("Password updated successfully.");
    // }

    //[HttpPost]
    //public async Task<IActionResult> ForgotPassword(string email, string newPassword)
    //{
        // Check if the user exists by email
    //    var user = _context.Users.FirstOrDefault(u => u.Email == email);
    //   if (user == null)
    //   {
    //       TempData["ErrorMessage"] = "User with this email does not exist.";
    //       return RedirectToAction("ForgotPassword");
    //  }

        // Update the user's password
    //    user.Password = newPassword;
    //    _context.Users.Update(user);
    //    await _context.SaveChangesAsync();  // Save the new password in the database

        // Set the success message
    //    TempData["SuccessMessage"] = "Password updated successfully.";
    //   return RedirectToAction("ForgotPassword");
    //}

}
