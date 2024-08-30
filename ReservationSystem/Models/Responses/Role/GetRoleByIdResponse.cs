using ReservationSystem.Models.Bases;
using System.Text.Json.Serialization;

namespace ReservationSystem.Models.Responses.Role
{
    public class GetRoleByIdResponse : ResponseBase
    {
        public GetRoleByIdResponse(string code) : base(code)
        {
        }

        public RoleModel RoleDetail { get; set; }
    }
}
