using Azure.Core;
using ReservationSystem.Helpers.DataAccess;
using ReservationSystem.Models.Entities;
using ReservationSystem.Models.Responses.User;
using ReservationSystem.Services.UserService.Interfaces;

namespace ReservationSystem.Services.UserService
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
