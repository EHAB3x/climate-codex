using System.ComponentModel.DataAnnotations;

namespace ClimateCodex.Server.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }
    }
}
