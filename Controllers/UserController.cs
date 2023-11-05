using _18_MVC_Example.Models;
using _18_MVC_Example.Models.ViewModels;
using _18_MVC_Example.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _18_MVC_Example.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserRepositories _userRepo;

        
        public UserController(IUserRepositories userRepo)
        {
            _userRepo = userRepo;

        }

        public IActionResult Index()
        {
            return View(_userRepo.Users);
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            var tempUser = _userRepo.Users.FirstOrDefault(x=>x.Username == user.Username && x.Password == user.Password);
            if (tempUser!=null)
            {
                return RedirectToAction("Student");
            }
            else 
            {
                ViewBag.Message = "Invalid User";
                return View(); 
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            _userRepo.InsertUser(user);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            return View(_userRepo.GetUserByID(id));
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _userRepo.UpdateUser(user);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            return View(_userRepo.GetUserByID(id));
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            //TODO: Emin misin sorulacak.
            _userRepo.DeleteUser(user.UserID);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            return View(_userRepo.GetUserByID(id));
        }

    }
}
