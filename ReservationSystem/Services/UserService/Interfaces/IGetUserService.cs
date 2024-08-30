using ReservationSystem.Models.Entities;
using ReservationSystem.Models.Requests.User;
using ReservationSystem.Models.Responses.User;

namespace ReservationSystem.Services.UserService.Interfaces
{
    public interface IGetUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<GetUserResponse> GetUserById(int id);
        Task<GetUserListResponse> GetUserListByPageNo(GetUserListRequest request);
    }
}
