using _18_MVC_Example.Models;
using _18_MVC_Example.Models.Context;

namespace _18_MVC_Example.Repositories
{
    public class EFUserRepositories : IUserRepositories
    {
        private readonly StudentDbContext _context;

        public EFUserRepositories(StudentDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users;

        public bool DeleteUser(int id)
        {
            _context.Users.Remove(GetUserByID(id));
            return _context.SaveChanges() > 0;
        }

        public User GetUserByID(int id)
        {
            return _context.Users.Find(id);
        }

        public bool InsertUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateUser(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChanges() > 0;
        }
    }
}
