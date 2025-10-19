using Callisto.Domain.Commands;
using Callisto.Domain.Entities;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Infra.Repositories
{
    public class TicketCommentRespository : ITicketCommentRepository
    {
        private readonly CallistoContext _context;
        public TicketCommentRespository(CallistoContext context)
        {
            _context = context;
        }

        public object Save(TicketComment comment)
        {
            _context.TicketComments.Add(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}
