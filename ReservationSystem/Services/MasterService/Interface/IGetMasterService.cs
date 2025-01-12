using ReservationSystem.API.Models.Entities;
using ReservationSystem.Models.Responses.Role;
using ReservationSystem.Models.Responses.User;

namespace ReservationSystem.API.Services.MasterService.Interface
{
    public interface IGetMasterService
    {
        Task<List<Role>> GetRoles();
    }
}
