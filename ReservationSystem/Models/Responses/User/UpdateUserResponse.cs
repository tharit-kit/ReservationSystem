using ReservationSystem.Models.Bases;

namespace ReservationSystem.Models.Responses.User
{
    public class UpdateUserResponse : ResponseBase
    {
        public UpdateUserResponse(string code) : base(code)
        {
        }

        public UserModel UserDetail { get; set; }
    }
}
