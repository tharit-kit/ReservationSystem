using ReservationSystem.API.Helpers.DataAccess;
using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;
using ReservationSystem.API.Services.UserService.Interfaces;
using ReservationSystem.Utils;

namespace ReservationSystem.API.Services.UserService
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly DataContext _context;
        private readonly IGetUserService _getUserService;

        public UpdateUserService(DataContext context, IGetUserService getUserService)
        {
            _context = context;
            _getUserService = getUserService;
        }

        public async Task<UpdateUserResponse> UpdateUserById(int id, UpdateUserRequest request)
        {
            try
            {
                //var user = await _getUserService.GetUserById(id);
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return new UpdateUserResponse("I02");
                }

                user.Email = request.Email;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;

                await _context.SaveChangesAsync();

                return new UpdateUserResponse("S01");
            }
            catch (Exception)
            {
                return new UpdateUserResponse("E01");
                throw;
            }
        }
    }
}
