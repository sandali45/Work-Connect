using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Profile()
        {
            // Retrieve the user's Id from the cookie
            string userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                // If no cookie is present, redirect to the sign-in page
                return RedirectToAction("SignIn", "SignIn");
            }

            // Convert the cookie value to an integer (user Id)
            int userId = int.Parse(userIdCookie);

            // Fetch the user's details from the database using the Id
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                // If user not found, redirect to sign-in
                return RedirectToAction("SignIn", "SignIn");
            }

            // Pass the user's details to the view
            ViewBag.UserName = user.Name;
            ViewBag.Email = user.Email;
            ViewBag.Occupation = user.Occupation ?? "Add Occupation";
            ViewBag.Address = user.Address ?? "Add Address";
            ViewBag.Description = user.Description ?? "Small description about self";

            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfileField([FromBody] ProfileFieldUpdateModel model)
        {
            // Retrieve the user's Id from the cookie
            string userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction("SignIn", "SignIn");
            }

            int userId = int.Parse(userIdCookie);

            // Fetch the user from the database
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("SignIn", "SignIn");
            }

            // Dynamically update the specific field
            switch (model.Field)
            {
                case "Description":
                    user.Description = model.Value;
                    break;
                // Handle other fields similarly if needed
                default:
                    return BadRequest("Invalid field");
            }

            // Save changes to the database
            _context.SaveChanges();

            return Ok();
        }
    }

    // Model for updating individual fields
    public class ProfileFieldUpdateModel
    {
        public string Field { get; set; }
        public string Value { get; set; }
    }
}
