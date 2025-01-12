using ReservationSystem.API.Models.Bases;

namespace ReservationSystem.API.Models.Responses.User
{
    public class UpdateUserResponse : ResponseBase
    {
        public UpdateUserResponse(string code) : base(code)
        {
        }

        public UserModel UserDetail { get; set; }
    }
}
