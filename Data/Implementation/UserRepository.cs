using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public UserRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == entity.Id);
            if (user == null) return false;
            user.Name = entity.Name;
            user.APaterno = entity.APaterno;
            user.AMaterno = entity.AMaterno;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.PilotId = entity.PilotId;
            user.ClientId = entity.ClientId;
            _dbContext.SaveChanges();
            return true;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
