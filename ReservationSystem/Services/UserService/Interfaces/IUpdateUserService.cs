using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;

namespace ReservationSystem.API.Services.UserService.Interfaces
{
    public interface IUpdateUserService
    {
        Task<UpdateUserResponse> UpdateUserById(int id, UpdateUserRequest request);
    }
}
