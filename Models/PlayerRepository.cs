using ESportsManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ESportsManager.Repositories {
    public class PlayerRepository {
        private static List<Player> _players = new List<Player>
        {
            new Player { Id = 1, Name = "João Silva", Nickname = "WolfKing", Role = "Assault", Score = new int[]{10, 8, 6}, TeamId = 1 },
            new Player { Id = 2, Name = "Carlos Lima", Nickname = "HotShot", Role = "Suporte", Score = new int[]{5, 3, 9}, TeamId = 1 },
            new Player { Id = 3, Name = "Marcos Dias", Nickname = "RavenX", Role = "Assault", Score = new int[]{7, 7, 8}, TeamId = 2 }
        };

        public List<Player> GetAll() {
            return _players;
        }

        public Player GetById(int id) {
            return _players.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Player player) {
            player.Id = _players.Any() ? _players.Max(p => p.Id) + 1 : 1;
            _players.Add(player);
        }

        public void Update(Player updatedPlayer) {
            var player = GetById(updatedPlayer.Id);
            if (player == null) return;

            player.Name = updatedPlayer.Name;
            player.Nickname = updatedPlayer.Nickname;
            player.Role = updatedPlayer.Role;
            player.Score = updatedPlayer.Score;
            player.TeamId = updatedPlayer.TeamId;
        }

        public void Delete(int id) {
            var player = GetById(id);
            if (player != null)
                _players.Remove(player);
        }
    }
}
