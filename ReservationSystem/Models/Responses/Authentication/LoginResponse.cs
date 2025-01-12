using ReservationSystem.API.Models.Bases;

namespace ReservationSystem.API.Models.Responses.Authentication
{
    public class LoginResponse : ResponseBase
    {
        public LoginResponse(string code) : base(code)
        {
        }

        public string? Token { get; set; }
    }
}
