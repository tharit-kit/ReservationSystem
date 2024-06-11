using ReservationSystem.Models.Bases;

namespace ReservationSystem.Models.Responses
{
    public class GetUserResponse : ResponseBase
    {
        public GetUserResponse(string code) : base(code) { }

        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int RoleId { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
    }
}
