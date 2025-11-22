namespace ESportsManager.Models {
    public class Player {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
        public int TeamId { get; set; }
        public int[] Score { get; set; }
    }
}