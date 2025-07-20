using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public UpdateUserCommand() { }

        public UpdateUserCommand(string firstName, string lastName, string email, string passwordHash, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            Phone = phone;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? Phone { get; set; }
        public Dictionary<string, string> Notifications { get; private set; } = new ();

        public bool Validate()
        {
            Notifications.Clear();

            if (FirstName != null)
            {
                if (FirstName.Length < 3)
                    Notifications.Add("FirstName", "O nome deve conter mais que 3 caracteres");
                if (FirstName.Any(char.IsDigit))
                    Notifications.Add("FirstName", "O nome não deve conter números");
            }

            if (LastName != null)
            {
                if (LastName.Length < 3)
                    Notifications.Add("LastName", "O sobrenome deve conter mais que 3 caracteres");
                if (LastName.Any(char.IsDigit))
                    Notifications.Add("LastName", "O sobrenome não deve conter números");
            }

            if (Email != null && !CreateUserCommand.IsValidEmail(Email))
                Notifications.Add("Email", "E-mail inválido");

            return Notifications.Count == 0;
        }
    }
}
