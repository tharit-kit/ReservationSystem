using ReservationSystem.API.Models.Bases;

namespace ReservationSystem.API.Models.Responses.User
{
    public class DeleteUserResponse : ResponseBase
    {
        public DeleteUserResponse(string code) : base(code)
        {
        }
    }
}
