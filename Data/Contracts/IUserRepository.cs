using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
    }
}
