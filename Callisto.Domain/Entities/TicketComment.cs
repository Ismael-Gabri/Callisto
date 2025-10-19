using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Callisto.Domain.Entities
{
    public class TicketComment
    {
        public TicketComment(int ticketId, int userId, string comment)
        {
            TicketId = ticketId;
            UserId = userId;
            Comment = comment;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; private set; }
        public int TicketId { get; private set; }
        public int UserId { get; private set; }

        [JsonIgnore]
        public Ticket Ticket { get; private set; }
        public User User { get; private set; }
        public string Comment { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
