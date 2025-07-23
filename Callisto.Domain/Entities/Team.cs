using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Callisto.Domain.Entities
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            IsActive = true;
            Users = new List<User>();
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        [JsonIgnore]
        public List<User>? Users { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void ChangeTeamName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Nome inválido.");

            Name = name;
        }
    }
}
