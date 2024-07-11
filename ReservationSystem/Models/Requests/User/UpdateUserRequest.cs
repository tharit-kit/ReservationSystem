using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservationSystem.Models.Requests.User
{
    public class UpdateUserRequest
    {
        /*[Required]
        [JsonPropertyName("id")]
        public string Id { get; set; }*/

        [Required]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [Required]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
