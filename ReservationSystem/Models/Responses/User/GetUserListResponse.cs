using ReservationSystem.Models.Bases;
using ReservationSystem.Models.Entities;
using System.Text.Json.Serialization;

namespace ReservationSystem.Models.Responses.User
{
    public class GetUserListResponse : ResponseBase
    {
        public GetUserListResponse(string code) : base(code) { }

        public List<UserModel> UserList { get; set; }
        public int TotalRow { get; set; }
    }
}
