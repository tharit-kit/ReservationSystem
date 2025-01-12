using ReservationSystem.API.Models.Entities;
using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;

namespace ReservationSystem.API.Services.UserService.Interfaces
{
    public interface IGetUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<GetUserResponse> GetUserById(int id);
        Task<GetUserListResponse> GetUserListByPageNo(GetUserListRequest request);
    }
}
