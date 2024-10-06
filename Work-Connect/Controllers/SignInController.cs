using Microsoft.AspNetCore.Mvc;

public class SignInController : Controller
{
    // Remove or comment out this field if you're not using the database for now
    // private readonly SignupDbContext _context;

    // Comment out or remove the constructor if it’s injecting DbContext
    // public SignInController(SignupDbContext context)
    // {
    //     _context = context;
    // }

    // This method handles the GET request to display the sign-in form
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();  // This will return the SignIn.cshtml view located in Views/SignIn
    }

    // You can also comment out the POST method if you don’t need authentication
    // [HttpPost]
    // public async Task<IActionResult> SignIn(string email, string password)
    // {
    //     // Simulating login without database logic
    //     if (email == "test@example.com" && password == "password")
    //     {
    //         return Ok("Login Successful");
    //     }
    //     else
    //     {
    //         return BadRequest("Invalid Email or Password");
    //     }
    // }
}
