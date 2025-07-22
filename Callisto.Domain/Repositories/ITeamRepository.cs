using Callisto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Callisto.Domain.Repositories
{
    public interface ITeamRepository
    {
        void Save(Team team);
        void Update(Team team);
        List<Team> GetAllTeams();
        Team GetTeamById(int teamId);
        void SaveChanges();
        void DeleteTeamById(int userId);
    }
}
