using Azure.Core;
using ReservationSystem.API.Helpers.DataAccess;
using ReservationSystem.API.Models.Responses.User;
using ReservationSystem.API.Services.UserService.Interfaces;
using ReservationSystem.Models.Entities;

namespace ReservationSystem.API.Services.UserService
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly DataContext _context;

        public DeleteUserService(DataContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserResponse> DeleteUserById(int id)
        {
            try
            {
                // if role = admin, check if curr user is admin or not
                // ??????????????????????

                using var transaction = _context.Database.BeginTransaction();
                var user = new User { Id = id };
                _context.Attach(user);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new DeleteUserResponse("S01");
            }
            catch (Exception)
            {
                return new DeleteUserResponse("E01");
                throw;
            }
        }
    }
}
