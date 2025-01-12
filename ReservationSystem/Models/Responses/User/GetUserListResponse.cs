using ReservationSystem.API.Models.Bases;
using System.Text.Json.Serialization;

namespace ReservationSystem.API.Models.Responses.User
{
    public class GetUserListResponse : ResponseBase
    {
        public GetUserListResponse(string code) : base(code) { }

        public List<UserModel> UserList { get; set; }
        public int TotalRow { get; set; }
    }
}
