using _18_MVC_Example.Models;
using _18_MVC_Example.Models.Context;

namespace _18_MVC_Example.Repositories
{
    public class EFSchoolRepositories : ISchoolRepositories
    {
        private readonly StudentDbContext _context;

        public EFSchoolRepositories(StudentDbContext context)
        {
            _context = context;
        }

        public IQueryable<School> Schools => _context.Schools;

        public bool DeleteSchool(int id)
        {
            _context.Schools.Remove(GetSchoolByID(id));
            return _context.SaveChanges() > 0;
        }

        public bool InsertSchool(School school)
        {
            _context.Schools.Add(school);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateSchool(School school)
        {
            _context.Schools.Update(school);
            return _context.SaveChanges() > 0;
        }

        public School GetSchoolByID(int id)
        {
            return _context.Schools.Find(id);
        }
    }
}
