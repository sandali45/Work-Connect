using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Work_Connect.Models;
using Work_Connect.Helpers;

public class SignUpController : Controller
{

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }


    }

