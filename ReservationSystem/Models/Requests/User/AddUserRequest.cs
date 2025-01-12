using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservationSystem.API.Models.Requests.User
{
    public class AddUserRequest
    {
        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [Required]
        [JsonPropertyName("roleId")]
        public int RoleId { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
