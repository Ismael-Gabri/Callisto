using Callisto.Domain.Enums;
using Callisto.Domain.Value_Objects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Entities
{
    public class User
    {
        protected User()
        {
            
        }
        private readonly IList<Ticket> _tickets = new List<Ticket>();
        public User(Name name, Email email, string passwordHash, Phone phone, int companyId)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Phone = phone;
            CompanyId = 5;
            TeamId = 5;
        }

        public int Id { get; private set; }
        public int CompanyId { get; private set; }
        public Company Company { get; private set; }
        public int TeamId { get; private set; }
        public Team Team { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public string PasswordHash { get; private set; }
        public string? ProfileImage { get; private set; }
        public ERole Role { get; private set; }
        public DateTime EntryDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public IReadOnlyCollection<Ticket> Tickets { get { return _tickets.ToArray(); } }
        public IDictionary<string, string> Notifications { get; private set; }

        public void SetPasswordHash(string Hash)
        {
            PasswordHash = Hash;
        }
    }
}
