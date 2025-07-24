using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.User_Commands.Input
{
    public class LoginCommand : ICommand
    {
        public LoginCommand() { }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
