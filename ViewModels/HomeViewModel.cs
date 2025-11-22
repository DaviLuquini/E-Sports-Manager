using System.Collections.Generic;
using ESportsManager.Models;

namespace ESportsManager.ViewModels {
    public class HomeViewModel {
        public List<Team> Teams { get; set; }
        public List<Player> Players { get; set; }
    }
}
