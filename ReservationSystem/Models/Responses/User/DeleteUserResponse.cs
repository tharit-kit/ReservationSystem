using ReservationSystem.Models.Bases;

namespace ReservationSystem.Models.Responses.User
{
    public class DeleteUserResponse : ResponseBase
    {
        public DeleteUserResponse(string code) : base(code)
        {
        }
    }
}
