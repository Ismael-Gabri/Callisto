using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Value_Objects
{
    public class Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Notifications = new Dictionary<string, string>();

            if (firstName.Length < 3)
            {
                Notifications.Add("FirstName", "O nome deve conter mais que 3 characteres");
            }
            if (firstName.Length > 20)
            {
                Notifications.Add("FirstName", "O nome deve conter menos que 20 characteres");
            }
            if (lastName.Length < 3)
            {
                Notifications.Add("LastName", "O sobrenome deve conter mais que 3 characteres");
            }
            if (lastName.Length > 20)
            {
                Notifications.Add("LastName", "O sobrenome deve conter menos que 20 characteres");
            }
            if (firstName.Any(char.IsDigit))
            {
                Notifications.Add("FirstName", "O nome não deve conter números");
            }
            if (lastName.Any(char.IsDigit))
            {
                Notifications.Add("LastName", "O sobrenome não deve conter números");
            }
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        [NotMapped]
        public IDictionary<string, string> Notifications { get; private set; }

        public void ChangeFirstName(string newFirstName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
                throw new Exception("Nome inválido.");

            FirstName = newFirstName;
        }

        public void ChangeLastName(string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newLastName))
                throw new Exception("Nome inválido.");

            LastName = newLastName;
        }
    }
}