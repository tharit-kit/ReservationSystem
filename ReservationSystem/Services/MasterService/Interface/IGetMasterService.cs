using ReservationSystem.Models.Responses.Role;
using ReservationSystem.Models.Responses.User;

namespace ReservationSystem.Services.MasterService.Interface
{
    public interface IGetMasterService
    {
        Task<GetRoleListResponse> GetRoles();
    }
}
