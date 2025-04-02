using System.ComponentModel.DataAnnotations;

namespace GamersInfoApp.Models
{
    public class Gamer
    {
        [Key]
        public int GamerID { get; set; }
        public string? GamerName { get; set; }
        public int? GamerAge { get; set; }

        //Add link for foreign key (1..*)
        public List<Gamer_Game>? Gamer_Games { get; set; }
}
}
