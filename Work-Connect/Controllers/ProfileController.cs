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
            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;
            ViewBag.Occupation = user.Occupation ?? "Add Occupation";
            ViewBag.Address = user.Address ?? "Add Address";
            ViewBag.Description = user.Description ?? "Small description about self";
            ViewBag.Experience = user.Experience ?? "Add your experience";
            ViewBag.Education = user.Education ?? "Add your education";
            ViewBag.Skills = user.Skills ?? "Add your skills";

            return View();
        }

        [HttpPost]
        public IActionResult UpdateExperience(string experience)
        {
            return UpdateProfileField("Experience", experience);
        }

        [HttpPost]
        public IActionResult UpdateEducation(string education)
        {
            return UpdateProfileField("Education", education);
        }

        [HttpPost]
        public IActionResult UpdateSkills(string skills)
        {
            return UpdateProfileField("Skills", skills);
        }

        private IActionResult UpdateProfileField(string field, string value)
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

            // Update the corresponding field based on the provided parameter
            switch (field)
            {
                case "Experience":
                    user.Experience = value;
                    break;
                case "Education":
                    user.Education = value;
                    break;
                case "Skills":
                    user.Skills = value;
                    break;
                default:
                    return BadRequest("Invalid field.");
            }

            // Save changes to the database
            _context.SaveChanges();

            return RedirectToAction("Profile");
        }


        [HttpPost]
        public IActionResult UpdateDescription(string description)
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

            user.Description = description;

            // Save changes to the database
            _context.SaveChanges();

            return RedirectToAction("Profile");
        }
    }
    public class ProfileFieldUpdateModel
    {
        public string Field { get; set; } // Name of the field to update (e.g., "description", "experience")
        public string Value { get; set; } // New value for the field
    }
}
