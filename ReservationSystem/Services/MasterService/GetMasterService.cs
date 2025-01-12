using Microsoft.EntityFrameworkCore;
using ReservationSystem.API.Helpers.DataAccess;
using ReservationSystem.API.Models.Entities;
using ReservationSystem.API.Services.MasterService.Interface;
using ReservationSystem.Models.Responses.Role;
using System.Linq;

namespace ReservationSystem.API.Services.MasterService
{
    public class GetMasterService : IGetMasterService
    {
        private readonly DataContext _context;

        public GetMasterService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();

                if (roles == null)
                {
                    return new List<Role> { };
                }

                return roles;
            }
            catch (Exception)
            {
                return new List<Role> { };
                throw;
            }
        }
    }
}
