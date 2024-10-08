using Microsoft.AspNetCore.Mvc;
using Work_Connect.Data;
using Work_Connect.Models;
using Microsoft.EntityFrameworkCore; // Ensure this is included

namespace Work_Connect.Controllers
{
    public class PostedjobController : Controller
    {

        public IActionResult postedjobhtml()
        {

            return View();
        }



    }

}
