using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Commands.User_Commands.Output
{
    public class UserDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int TeamId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public string? ProfileImage { get; set; }
        public string Role { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
