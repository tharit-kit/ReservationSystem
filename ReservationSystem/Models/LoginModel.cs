using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Models
{
    public class LoginModel
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
