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
            CreatedAt = DateTime.UtcNow;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cnpj { get; private set; }         
        public string Email { get; private set; }     
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new Exception("Nome da empresa inválido.");

            Name = newName;
        }

        public void ChangeCnpj(string newCnpj)
        {
            if (string.IsNullOrWhiteSpace(newCnpj))
                throw new Exception("CNPJ inválido.");

            Cnpj = newCnpj;
        }

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new Exception("Email inválido.");

            Email = newEmail;
        }

        public void ChangePhone(string newPhone)
        {
            if (string.IsNullOrWhiteSpace(newPhone))
                throw new Exception("Telefone inválido.");

            Phone = newPhone;
        }

        public void ChangeAddress(string newAddress)
        {
            if (string.IsNullOrWhiteSpace(newAddress))
                throw new Exception("Endereço inválido.");

            Address = newAddress;
        }
    }
}
