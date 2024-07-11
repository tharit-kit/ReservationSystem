using ReservationSystem.Models.Requests.User;
using ReservationSystem.Models.Responses.User;

namespace ReservationSystem.Services.UserService.Interfaces
{
    public interface IUpdateUserService
    {
        Task<UpdateUserResponse> UpdateUserById(int id, UpdateUserRequest request);
    }
}
