using Microsoft.EntityFrameworkCore;
using MyOTP.DataAccess;
using MyOTP.Models;

namespace MyOTP.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgresDbContext _dbContext;

        public UserRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Username == username);
        }

        public User GetById(int id)
        {
            return _dbContext.Set<User>().Find(id);
        }

        public void Add(User entity)
        {
            _dbContext.Set<User>().Add(entity);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Set<User>().ToList();
        }
    }
}
