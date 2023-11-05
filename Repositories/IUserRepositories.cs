using _18_MVC_Example.Models;

namespace _18_MVC_Example.Repositories
{
    public interface IUserRepositories
    {
        IQueryable<User> Users { get; }

        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        User GetUserByID(int id);
    }
}
