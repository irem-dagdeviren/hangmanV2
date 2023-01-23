using System.ComponentModel.DataAnnotations;

namespace hangmanV1.Model.Entity
{
    public class Words
    {
        [Key]
        public int ID { get; set; } = 0;
        [Required]
        public string? Word { get; set; } = string.Empty;

    }
}