using Microsoft.AspNetCore.Mvc;

namespace Work_Connect.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
