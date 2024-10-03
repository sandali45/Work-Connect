using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


public class SignInController : Controller
{
    private readonly SignupDbContext _context;

    public SignInController(SignupDbContext context)
    {
        _context = context;
    }

    // This method handles the GET request to display the sign-in form
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();  // This will return the SignIn.cshtml view located in Views/SignIn
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

        if (user != null)
        {
            // User is authenticated
            return Ok("Login Successful");
        }
        else
        {
            // Authentication failed
            return BadRequest("Invalid Email or Password");
        }
    }
}
