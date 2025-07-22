using Callisto.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.Company
{
    public class UpdateCompanyCommand : ICommand
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cnpj { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool Validate()
        {
            return true;
        }
    }
}
