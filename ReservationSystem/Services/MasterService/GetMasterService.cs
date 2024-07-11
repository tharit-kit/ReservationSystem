using Microsoft.EntityFrameworkCore;
using ReservationSystem.Helpers.DataAccess;
using ReservationSystem.Models.Responses.Role;
using ReservationSystem.Services.MasterService.Interface;
using System.Linq;

namespace ReservationSystem.Services.MasterService
{
    public class GetMasterService : IGetMasterService
    {
        private readonly DataContext _context;

        public GetMasterService(DataContext context)
        {
            _context = context;
        }

        public async Task<GetRoleListResponse> GetRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();

                if (roles == null)
                {
                    return new GetRoleListResponse("S02");
                }

                return new GetRoleListResponse("S01")
                {
                    RoleList = roles.Select(s => new RoleModel
                    {
                        Id = s.Id,
                        Description = s.Description,
                    }).ToList(),
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
