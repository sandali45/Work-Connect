using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Work_Connect.Data;
using Work_Connect.Models;

namespace Work_Connect.Controllers
{
    public class EditDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult EditDetails()
        {
            string userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction("SignIn", "SignIn");
            }

            int userId = int.Parse(userIdCookie);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return RedirectToAction("SignIn", "SignIn");
            }

            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;
            ViewBag.Address = user.Address ?? "Add Address";
            ViewBag.Occupation = user.Occupation ?? "Add Occupation";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditDetailsHtml([Bind("Name,Email,Address,Occupation")] User user)
        {
            string userIdCookie = Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userIdCookie))
            {
                return RedirectToAction("SignIn", "SignIn");
            }
            int userId = int.Parse(userIdCookie);


            var existingUser = await _context.Users.FindAsync(userId);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            try
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Address = user.Address;
                existingUser.Occupation = user.Occupation;

                await _context.SaveChangesAsync();
                TempData["Message"] = "User details updated successfully.";
                return RedirectToAction("Profile", "Profile");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(userId))
                {
                    return NotFound("User not found.");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                return View("EditDetails", existingUser); // Ensure you're returning the correct view name here
            }
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


    }
}
