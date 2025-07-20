using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Entities
{
    public class Company
    {
        public Company(string name, string cnpj, string email, string phone, string address)
        {
            Name = name;
            Cnpj = cnpj;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }         
        public string Email { get; private set; }     
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
