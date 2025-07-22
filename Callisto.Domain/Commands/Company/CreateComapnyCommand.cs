using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Company
{
    public class CreateComapnyCommand : ICommand
    {
        public CreateComapnyCommand() {  }
        public CreateComapnyCommand(string name, string cnpj, string email, string phone, string address)
        {
            Name = name;
            Cnpj = cnpj;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Validate()
        {
            return true;
        }
    }
}
