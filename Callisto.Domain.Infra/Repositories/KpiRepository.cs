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
    }
}
