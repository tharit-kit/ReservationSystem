using ReservationSystem.API.Models.Responses.User;
using ReservationSystem.Models.Requests.User;

namespace ReservationSystem.API.Services.UserService.Interfaces
{
    public interface IDeleteUserService
    {
        Task<DeleteUserResponse> DeleteUserById(int id);
    }
}
