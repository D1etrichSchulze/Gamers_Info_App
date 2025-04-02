using System.ComponentModel.DataAnnotations;

namespace GamersInfoApp.Models
{
    public class Game
    {
        [Key]
        public int GameID { get; set; }
        public string? GameName { get; set; }
        public string?GameGenre { get; set; }

        //Add link for foreign key (1..*)
        public List<Gamer_Game>? Gamer_Games { get; set; }
    }
}
