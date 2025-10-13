using Callisto.Domain.Enums.Ticket;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Infra.Repositories
{
    public class KpiRepository : IKpiRepository
    {
        private readonly CallistoContext _context;
        public KpiRepository(CallistoContext context)
        {
            _context = context;
        }

        public async Task<int> OpenTicketstotal()
        {
            int count = await _context.Tickets
                              .Where(t => t.Status == 0)
                              .CountAsync();

            return count;
        }

        public async Task<Dictionary<int, int>> GetTicketsCountByStatusAsync()
        {
            var validStatuses = new[]
            {
        ETicketStatus.Open,
        ETicketStatus.InProgress,
        ETicketStatus.Resolved,
        ETicketStatus.Closed,
        ETicketStatus.Cancelled
    };

            var counts = await _context.Tickets
                .Where(t => validStatuses.Contains(t.Status))
                .GroupBy(t => t.Status)
                .Select(g => new { Status = (int)g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Status, x => x.Count);

            for (int i = 0; i <= 4; i++)
            {
                if (!counts.ContainsKey(i))
                    counts[i] = 0;
            }

            return counts;
        }
    }
}
