using System.ComponentModel.DataAnnotations;

namespace hangmanV1.Model
{
    public class Game
    {
        [Key]
        public int ID { get; set; }
        public string previousGuess { get; set; }
        [Required]
        public string quesiton { get; set; }
        [Range(0, 5)]
        public int lifeCount { get; set; }
    }
}
