using Microsoft.AspNetCore.Mvc;

namespace Work_Connect.Controllers
{
    public class PostJobController : Controller
    {
        public IActionResult postJob()
        {
            return View();
        }

        public IActionResult waitingForApproval()
        {
            return View();
        }
    }
}
