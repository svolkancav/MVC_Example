using _18_MVC_Example.Models;

namespace _18_MVC_Example.Repositories
{
    public interface ISchoolRepositories
    {
        IQueryable<School> Schools { get; }

        bool InsertSchool(School schools);
        bool UpdateSchool(School schools);
        bool DeleteSchool(int id);
        School GetSchoolByID(int id);
    }
}
