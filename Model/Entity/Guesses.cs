using System.ComponentModel.DataAnnotations;

namespace hangmanV1.Model
{
    public class Guesses
    {
        [Key]
        public int GuessID { get; set; }
        public char letter { get; set; }
    }
}
