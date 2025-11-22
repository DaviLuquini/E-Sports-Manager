using ESportsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ESportsManager.Repositories {
    public class TeamRepository {
        private static readonly List<Team> _teams = new List<Team>
        {
            new Team {
                Id = 1,
                Name = "Fire Wolves",
                Trophies = new string[] { "Summer Cup 2023" },
                Players = new Player[]
                {
                    new Player { Id = 1, Name = "João Silva", Nickname = "WolfKing", Role = "Assault", Score = new int[]{10, 8, 6}, TeamId = 1 },
                    new Player { Id = 2, Name = "Carlos Lima", Nickname = "HotShot", Role = "Suporte", Score = new int[]{5, 3, 9}, TeamId = 1 }
                }
            },
            new Team {
                Id = 2,
                Name = "Night Ravens",
                Trophies = new string[] { "Winter Clash 2024" },
                Players = new Player[]
                {
                    new Player { Id = 3, Name = "Marcos Dias", Nickname= "RavenX", Role = "Assault", Score = new int[]{7, 7, 8}, TeamId = 2 }
                }
            }
        };

        public List<Team> GetAll() {
            return _teams;
        }

        public Team GetById(int id) {
            return _teams.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Team team) {
            team.Id = _teams.Any() ? _teams.Max(t => t.Id) + 1 : 1;
            _teams.Add(team);
        }

        public void Update(Team updatedTeam) {
            var team = GetById(updatedTeam.Id);
            if (team == null) return;

            team.Name = updatedTeam.Name;
            team.Players = updatedTeam.Players;
            team.Trophies = updatedTeam.Trophies;
        }

        public void Delete(int id) {
            var team = GetById(id);
            if (team != null)
                _teams.Remove(team);
        }
    }
}
