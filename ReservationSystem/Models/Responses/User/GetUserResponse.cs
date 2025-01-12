using ReservationSystem.API.Models.Bases;

namespace ReservationSystem.API.Models.Responses.User
{
    public class GetUserResponse : ResponseBase
    {
        public GetUserResponse(string code) : base(code) { }

        public UserModel UserDetail { get; set; }
    }
}
