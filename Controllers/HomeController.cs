using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementSystem.Models;
using TaskManagementSystem.Data;

namespace TaskManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // Fields
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        // Constructor
        public HomeController(
            ILogger<HomeController> logger,
            AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DatabaseTest()
        {
            var userCount = _context.UserInfo.Count();

            return Content($"Database connected successfully! Total users: {userCount}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}