using ReservationSystem.Models.Entities;
using ReservationSystem.Models.Responses;

namespace ReservationSystem.Services.UserService.Interfaces
{
    public interface IGetUserService
    {
        Task<GetUserResponse> GetUserByEmail(string email);
        Task<GetUserResponse> GetUserById(int id);
    }
}
