using ReservationSystem.Models.Bases;

namespace ReservationSystem.Models.Responses.User
{
    public class GetUserResponse : ResponseBase
    {
        public GetUserResponse(string code) : base(code) { }

        public UserModel UserDetail { get; set; }
    }
}
