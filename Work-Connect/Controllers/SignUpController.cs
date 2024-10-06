using Microsoft.AspNetCore.Mvc;

public class SignUpController : Controller
{
    // Temporarily remove or comment out the `SignupDbContext` dependency
    // private readonly SignupDbContext _context;

    // Comment out the constructor that injects `SignupDbContext`
    // public SignUpController(SignupDbContext context)
    // {
    //     _context = context;
    // }

    // This method handles the GET request to display the sign-up form
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();  // This will return the SignUp.cshtml view located in Views/SignUp
    }

    // You can also comment out the POST method for now if you're just testing the view
    // [HttpPost]
    // public async Task<IActionResult> SignUp(string name, string email, string password)
    // {
    //     return Ok("User created successfully.");
    // }
}
