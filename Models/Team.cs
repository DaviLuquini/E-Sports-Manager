using System.Linq;

namespace ESportsManager.Models {
    public class Team {
        public int Id { get; set; }
        public string Name { get; set; }
        public Player[] Players { get; set; }
        public string[] Trophies { get; set; }
        public int[] Scores {
            get {
                if (Players == null)
                    return new int[0];

                return Players
                    .Where(p => p.Score != null)
                    .SelectMany(p => p.Score)
                    .ToArray();
            }
        }
    }
}