using Callisto.Domain.Commands;
using Callisto.Domain.Commands.Contracts;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve conter pelo menos 6 caracteres")]
        public string Password { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Email)
                && CreateUserCommand.IsValidEmail(Email)
                && !string.IsNullOrWhiteSpace(Password)
                && Password.Length >= 6;
        }
    }
}
