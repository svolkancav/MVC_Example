using _18_MVC_Example.Models;
using _18_MVC_Example.Models.Context;

namespace _18_MVC_Example.Repositories
{
    public class EFStudentRepositories : IStudentRepositories
    {
        //Dependency Injection
        private readonly StudentDbContext _context;

        public EFStudentRepositories(StudentDbContext context)
        {
            _context = context;
        }
        public IQueryable<Student> Students => _context.Students;

        public bool DeleteStudent(int id)
        {
            _context.Students.Remove(GetStudentByID(id));
            return _context.SaveChanges() > 0;
        }

        public Student GetStudentByID(int id)
        {
            return _context.Students.Find(id);
        }

        public bool InsertStudent(Student student)
        {
            _context.Students.Add(student);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            return _context.SaveChanges() > 0;
        }
    }
}
