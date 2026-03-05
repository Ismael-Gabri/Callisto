using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Enums.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Callisto.Domain.Commands
{
    public class CreateTicketCommand : ICommand
    {
        public CreateTicketCommand() { }

        public CreateTicketCommand(int userId, string title, string description, ETicketPriority priority, int team, int? technicianId = null)
        {
            Title = title;
            Description = description;
            Priority = priority;
            UserId = userId;
            Team = team;
            TechnicianId = technicianId;
        }

        public int UserId { get; set; }
        public int Team { get; set; }
        public int? TechnicianId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ETicketPriority Priority { get; set; }

        public Dictionary<string, string> Notifications { get; private set; } = new();

        public bool Validate()
        {
            Notifications.Clear();

            if (string.IsNullOrWhiteSpace(Title) || Title.Length < 5)
                Notifications.TryAdd("Title", "O título deve conter pelo menos 5 caracteres");

            if (string.IsNullOrWhiteSpace(Description) || Description.Length < 10)
                Notifications.TryAdd("Description", "A descrição deve conter pelo menos 10 caracteres");

            if (TechnicianId.HasValue && TechnicianId.Value <= 0)
                Notifications.TryAdd("TechnicianId", "Técnico inválido");

            return Notifications.Count == 0;
        }
    }
}
