using System.Collections.Generic;
using Domain.Model;

namespace Data.Contracts
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Users GetUserByEmail(string email);
        List<Users> GetAllUsers();
        List<Users> GetAdminUsers();
        Users GetAdminUserById(int userId);
        bool AddAdminUser(Users user);
        bool UpdateAdminUser(Users user);
        bool DeleteAdminUser(int userId);
        bool AssignUserType(int userId, UserType userType);
    }
}