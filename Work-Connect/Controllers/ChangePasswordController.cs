using Microsoft.AspNetCore.Mvc;

namespace Work_Connect.Controllers
{
    public class ChangePasswordController : Controller
    {
        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
