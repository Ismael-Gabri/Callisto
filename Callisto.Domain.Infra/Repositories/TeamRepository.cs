using Callisto.Domain.Entities;
using Callisto.Domain.Infra.Contexts;
using Callisto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Callisto.Domain.Infra.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly CallistoContext _context;
        public TeamRepository(CallistoContext context)
        {
            _context = context;
        }

        public List<Team> GetAllTeams()
        {
            return _context.Teams.ToList();
        }

        public Team GetTeamById(int teamId)
        {
            return _context.Teams.FirstOrDefault(n => n.Id == teamId);
        }

        public void Save(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Team team)
        {
            _context.Teams.Update(team);
        }

        public void DeleteTeamById(int teamId)
        {
            var team = _context.Teams.Find(teamId);

            if (team != null)
            {
                _context.Teams.Remove(team);
                _context.SaveChanges();
            }
        }
    }
}
