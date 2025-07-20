using Callisto.Domain.Commands.User_Commands.Output;
using Callisto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Repositories
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void DeleteUserById(int userId);
    }
}
