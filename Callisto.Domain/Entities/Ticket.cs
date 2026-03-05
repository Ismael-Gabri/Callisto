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
        private Ticket() { }

        public Ticket(int companyId, int teamId, int userId, string title, string description, ETicketPriority priority)
        {
            UserId = userId;
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
        public int? TechnicianId { get; private set; }
        public User? Technician { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public ETicketPriority Priority { get; private set; }
        public ETicketStatus Status { get; private set; }

        public DateTime CreationDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? ResolutionDate { get; private set; }

        private readonly List<TicketComment> _comments = new();
        public IReadOnlyCollection<TicketComment> Comments => _comments.AsReadOnly();

        public void AddComment(TicketComment comment)
        {
            _comments.Add(comment);
            UpdateDate = DateTime.UtcNow;
        }

        public void ChangeTeam(int teamId)
        {
            TeamId = teamId;
            UpdateDate = DateTime.UtcNow;
        }

        public void AssignTo(int technicianId)
        {
            TechnicianId = technicianId;
            UpdateDate = DateTime.UtcNow;
        }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length < 5)
                throw new ArgumentException("O título deve ter no mínimo 5 caracteres.");

            Title = title;
            UpdateDate = DateTime.UtcNow;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length < 10)
                throw new ArgumentException("A descrição deve ter no mínimo 10 caracteres.");

            Description = description;
            UpdateDate = DateTime.UtcNow;
        }

        public void ChangePriority(ETicketPriority priority)
        {
            if (!Enum.IsDefined(typeof(ETicketPriority), priority))
                throw new ArgumentException("Prioridade inválida.");

            Priority = priority;
            UpdateDate = DateTime.UtcNow;
        }

        public void ChangeStatus(ETicketStatus status)
        {
            if (!Enum.IsDefined(typeof(ETicketStatus), status))
                throw new ArgumentException("Status inválido.");

            Status = status;
            UpdateDate = DateTime.UtcNow;
        }

        public void SetResolutionDate(DateTime date)
        {
            if (date < DateTime.UtcNow.AddYears(-10))
                throw new ArgumentException("Data de resolução inválida.");

            ResolutionDate = date;
            UpdateDate = DateTime.UtcNow;
        }
    }
}
