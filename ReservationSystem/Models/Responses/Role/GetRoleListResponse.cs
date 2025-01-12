using ReservationSystem.API.Models.Bases;
using ReservationSystem.Models.Responses.User;
using System.Text.Json.Serialization;

namespace ReservationSystem.API.Models.Responses.Role
{
    public class GetRoleListResponse : ResponseBase
    {
        public GetRoleListResponse(string code) : base(code) { }

        [JsonPropertyName("roleList")]
        public List<RoleModel> RoleList { get; set; }
    }
}
