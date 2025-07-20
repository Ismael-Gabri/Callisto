using Callisto.Domain.Entities;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CallistoContext _context;
        public UserRepository(CallistoContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public void Save(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
