using Callisto.Domain.Commands.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Callisto.Domain.Commands
{
    public class CreateUserCommand : ICommand
    {
        public CreateUserCommand() { }

        public CreateUserCommand(string firstName, string lastName, string email, string passwordHash, string phone, int companyId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
            Phone = phone;
            CompanyId = companyId;
        }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve conter no mínimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "O nome deve conter no máximo 20 caracteres")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "O nome não deve conter números")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [MinLength(3, ErrorMessage = "O sobrenome deve conter no mínimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "O sobrenome deve conter no máximo 20 caracteres")]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "O sobrenome não deve conter números")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve conter pelo menos 6 caracteres")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Phone { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CompanyId inválido")]
        public int CompanyId { get; set; }

        public Dictionary<string, string> Notifications { get; private set; } = new();

        public bool Validate()
        {
            Notifications.Clear();

            if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 3 || FirstName.Length > 20 || FirstName.Any(char.IsDigit))
                Notifications["FirstName"] = "Nome inválido";

            if (string.IsNullOrWhiteSpace(LastName) || LastName.Length < 3 || LastName.Length > 20 || LastName.Any(char.IsDigit))
                Notifications["LastName"] = "Sobrenome inválido";

            if (!IsValidEmail(Email))
                Notifications["Email"] = "E-mail inválido";

            if (string.IsNullOrWhiteSpace(PasswordHash) || PasswordHash.Length < 6)
                Notifications["PasswordHash"] = "Senha inválida";

            if (string.IsNullOrWhiteSpace(Phone))
                Notifications["Phone"] = "Telefone obrigatório";

            if (CompanyId <= 0)
                Notifications["CompanyId"] = "CompanyId inválido";

            return Notifications.Count == 0;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
