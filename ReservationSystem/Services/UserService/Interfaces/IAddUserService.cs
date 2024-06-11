using ReservationSystem.Models.Requests;
using ReservationSystem.Models.Responses;

namespace ReservationSystem.Services.UserService.Interfaces
{
    public interface IAddUserService
    {
        Task<AddUserResponse> AddUser(AddUserRequest request);
    }
}
