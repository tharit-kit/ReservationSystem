using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;

namespace ReservationSystem.API.Services.UserService.Interfaces
{
    public interface IAddUserService
    {
        Task<AddUserResponse> AddUser(AddUserRequest request);
    }
}
