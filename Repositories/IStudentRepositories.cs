using _18_MVC_Example.Models;

namespace _18_MVC_Example.Repositories
{
    public interface IStudentRepositories
    {
        IQueryable<Student> Students { get; }

        bool InsertStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int id);    
        Student GetStudentByID(int id);
    }
}
