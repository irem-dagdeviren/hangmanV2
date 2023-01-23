using System.ComponentModel.DataAnnotations;



namespace hangmanV1.Model.Entity
{
    public class Users
    {
        [Key] 
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}