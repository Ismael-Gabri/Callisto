using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Repositories
{
    public interface IKpiRepository
    {
        Task<int> OpenTicketstotal();
        public Task<Dictionary<int, int>> GetTicketsCountByStatusAsync();
    }
}
