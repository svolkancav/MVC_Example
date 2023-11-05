using _18_MVC_Example.Models;
using _18_MVC_Example.Models.Context;
using _18_MVC_Example.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _18_MVC_Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserRepositories _userRepo;
        public HomeController(ILogger<HomeController> logger, IUserRepositories userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        const string Username = "username";
        const string Firstname = "firstname";
        const string UserRole = "userRole";    

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            
            var obj = _userRepo.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
            if (obj != null)
            {

                return RedirectToAction("Index","User");
            }
            else
            {
                ModelState.AddModelError(nameof(user.Username), "User not found or matched");
                ModelState.AddModelError(nameof(user.Password), "User not found or matched");
                return View(user);
            }
            
        }

        public IActionResult Index()
        {
			
			return View(_userRepo.Users);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}