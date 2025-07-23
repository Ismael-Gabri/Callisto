using Callisto.Domain.Commands.Contracts;
using Callisto.Domain.Enums.Ticket;
using System;
using System.Collections.Generic;

namespace Callisto.Domain.Commands
{
    public class UpdateTicketCommand : ICommand
    {
        public int Id { get; set; } 
        public int? TeamId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ETicketPriority? Priority { get; set; }
        public ETicketStatus? Status { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public Dictionary<string, string> Notifications { get; private set; } = new();

        public bool Validate()
        {
            Notifications.Clear();

            if (Id <= 0)
                Notifications.Add("TicketId", "Id do ticket inválido");

            if (Title != null && Title.Length < 5)
                Notifications.Add("Title", "O título deve conter pelo menos 5 caracteres");

            if (Description != null && Description.Length < 10)
                Notifications.Add("Description", "A descrição deve conter pelo menos 10 caracteres");

            if (Priority.HasValue && !Enum.IsDefined(typeof(ETicketPriority), Priority.Value))
                Notifications.Add("Priority", "Prioridade inválida");

            if (Status.HasValue && !Enum.IsDefined(typeof(ETicketStatus), Status.Value))
                Notifications.Add("Status", "Status inválido");

            if (ResolutionDate.HasValue && ResolutionDate.Value < DateTime.UtcNow.AddYears(-10))
                Notifications.Add("ResolutionDate", "Data de resolução inválida");

            return Notifications.Count == 0;
        }
    }
}
