using ReservationSystem.Models.Bases;

namespace ReservationSystem.Models.Responses.Authentication
{
    public class LoginResponse : ResponseBase
    {
        public LoginResponse(string code) : base(code)
        {
        }

        public string? Token { get; set; }
    }
}
