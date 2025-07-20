using Callisto.Domain.Enums.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Entities
{
    public class Ticket
    {
        public Ticket(int companyId, int teamId, string title, string description, ETicketPriority priority)
        {
            CompanyId = companyId;
            TeamId = teamId;
            Title = title;
            Description = description;
            Priority = priority;
            CreationDate = DateTime.UtcNow;
            Status = ETicketStatus.Open;
        }

        public int Id { get; private set; }
        public int CompanyId { get; private set; }
        public Company Company { get; private set; }
        public int TeamId { get; private set; }
        public Team Team { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public ETicketPriority Priority { get; private set; }
        public ETicketStatus Status { get; private set; }

        public DateTime CreationDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? ResolutionDate { get; private set; }
    }
}
