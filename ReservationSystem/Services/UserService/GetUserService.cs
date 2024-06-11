using Microsoft.EntityFrameworkCore;
using ReservationSystem.Helpers.DataAccess;
using ReservationSystem.Models.Entities;
using ReservationSystem.Models.Responses;
using ReservationSystem.Services.UserService.Interfaces;

namespace ReservationSystem.Services.UserService
{
    public class GetUserService : IGetUserService
    {
        private readonly DataContext _context;

        public GetUserService(DataContext context)
        {
            _context = context;
        }

        public async Task<GetUserResponse> GetUserByEmail(string email)
        {
            try
            {
                var user = await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(s => s.Email == email);

                if (user == null)
                {
                    return new GetUserResponse("S02");
                }

                return new GetUserResponse("S01")
                {
                    Id = user.Id,
                    Email = email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                };
            }
            catch (Exception)
            {

                throw;
            }
            
            //throw new NotImplementedException();
        }

        public async Task<GetUserResponse> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(s => s.Id == id);
            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }
    }
}
