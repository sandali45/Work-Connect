using Microsoft.AspNetCore.Mvc;

namespace Work_Connect.Controllers
{
    public class AdminUsersController : Controller
    {
        public IActionResult AdminUsers()
        {
            return View();
        }
    }
}
