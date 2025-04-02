using System.ComponentModel.DataAnnotations;

namespace GamersInfoApp.Models
{
    public class Gamer_Game
    {
        [Key]
        public int GamerGameID { get; set; }
        
        public int GamerID { get; set; }
        public int GameID { get; set; }
        public int HoursPlayed { get; set; }

        //reference keys
        public Gamer? Gamer { get; set; }
        public Game? Game { get; set; }
    }
}
