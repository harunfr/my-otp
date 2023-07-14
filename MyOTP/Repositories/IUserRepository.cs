using MyOTP.Models;
using System.Collections.Generic;

namespace MyOTP.Repositories
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        User GetById(int id);
        void Add(User user);
        List<User> GetAll();
    }
}
