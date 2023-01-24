using System.ComponentModel.DataAnnotations;

namespace deneme2.Model
{
    public class Guesses
    {
        [Key]
        public int GuessID { get; set; }
        public char letter { get; set; }
    }
}
