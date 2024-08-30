using Microsoft.EntityFrameworkCore;
using ReservationSystem.Helpers.DataAccess;
using ReservationSystem.Models.Entities;
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

        public async Task<List<Role>> GetRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();

                if (roles == null) { 
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
