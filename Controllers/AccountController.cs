using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;
using TaskManagementSystem.ViewModels;
using TaskManagementSystem.Helpers;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            // Check validation
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check duplicate email
            bool emailExists = _context.UserInfo
                .Any(user => user.Email == model.Email);

            if (emailExists)
            {
                ModelState.AddModelError(
                    "Email",
                    "This email is already registered."
                );

                return View(model);
            }

            // Generate password hash and salt
            PasswordHelper.CreatePasswordHash(
                model.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt
            );

            // Create UserInfo object
            var newUser = new UserInfo
            {
                Name = model.Name.Trim(),
                Email = model.Email.Trim(),
                DateOfBirth = model.DateOfBirth!.Value,

                PasswordHash = Convert.ToBase64String(passwordHash),
                PasswordSalt = Convert.ToBase64String(passwordSalt),

                CreatedDate = DateTime.Now
            };

            // Add user
            _context.UserInfo.Add(newUser);

            // Save to SQL Server
            _context.SaveChanges();

            TempData["SuccessMessage"] =
                "Account created successfully!";

            return RedirectToAction("Register");
        }
    }
}