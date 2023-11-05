using _18_MVC_Example.Models;
using _18_MVC_Example.Models.ViewModels;
using _18_MVC_Example.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _18_MVC_Example.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepositories _repoStudent;
        private readonly ISchoolRepositories _repoSchool;

        public StudentController(IStudentRepositories repoStudent, ISchoolRepositories repoSchool)
        {
            _repoStudent = repoStudent;
            _repoSchool = repoSchool;

        }

        public IActionResult Index()
        {
            return View(_repoStudent.Students);
        }

        public IActionResult Create()
        {
            ViewBag.Schools = _repoSchool.Schools;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repoStudent.InsertStudent(student);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            UpdateVMStudent updateVM = new UpdateVMStudent();
            updateVM.Student = _repoStudent.GetStudentByID(id);
            updateVM.Schools = _repoSchool.Schools.ToList();
            return View(updateVM);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repoStudent.UpdateStudent(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            UpdateVMStudent updateVM = new UpdateVMStudent();
            updateVM.Student = _repoStudent.GetStudentByID(id);
            updateVM.Schools = _repoSchool.Schools.ToList();
            return View(updateVM);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            //TODO: Emin misin sorulacak.
            _repoStudent.DeleteStudent(student.StudentId);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {

            return View(_repoStudent.GetStudentByID(id));
        }

    }
}
