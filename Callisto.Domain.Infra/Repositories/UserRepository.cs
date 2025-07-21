using Callisto.Domain.Commands;
using Callisto.Domain.Entities;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using Callisto.Domain.Value_Objects;
using Microsoft.EntityFrameworkCore;
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
            return _context.Users.Include(u => u.Company).Include(u => u.Team).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Include(u => u.Company).Include(u => u.Team).FirstOrDefault(u => u.Id == userId);
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
        public void DeleteUserById(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
