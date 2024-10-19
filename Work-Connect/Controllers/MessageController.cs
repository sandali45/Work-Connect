using Microsoft.AspNetCore.Mvc;

namespace Work_Connect.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Message()
        {
            return View();
        }
    }
}
