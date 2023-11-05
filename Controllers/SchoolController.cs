using _18_MVC_Example.Models;
using _18_MVC_Example.Models.ViewModels;
using _18_MVC_Example.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _18_MVC_Example.Controllers
{
    public class SchoolController : Controller
    {
        private readonly IStudentRepositories _repoStudent;
        private readonly ISchoolRepositories _repoSchool;

        public SchoolController(IStudentRepositories repoStudent, ISchoolRepositories repoSchool)
        {
            _repoStudent = repoStudent;
            _repoSchool = repoSchool;

        }
        public IActionResult Index()
        {
            return View(_repoSchool.Schools);
        }

        public IActionResult Create()
        {
            ViewBag.Students = _repoStudent.Students;
            return View();
        }

        [HttpPost]
        public IActionResult Create(School school)
        {
            _repoSchool.InsertSchool(school);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            School school= _repoSchool.GetSchoolByID(id);
            return View(school);
        }

        [HttpPost]
        public IActionResult Edit(School school)
        {
            _repoSchool.UpdateSchool(school);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            School school = _repoSchool.GetSchoolByID(id);
            return View(school);
        }

        [HttpPost]
        public IActionResult Delete(School school)
        {
            //TODO: Emin misin sorulacak.
            _repoSchool.DeleteSchool(school.SchooldId);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            return View(_repoSchool.GetSchoolByID(id));
        }


    }
}
