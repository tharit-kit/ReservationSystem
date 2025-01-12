using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.API.Helpers.DataAccess;
using ReservationSystem.API.Helpers.Hashing;
using ReservationSystem.API.Models.Entities;
using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;
using ReservationSystem.API.Services.UserService.Interfaces;

namespace ReservationSystem.API.Services.UserService
{
    public class AddUserService : IAddUserService
    {
        private readonly DataContext _context;
        private readonly IGetUserService _getUserService;

        public AddUserService(DataContext context, IGetUserService getUserService)
        {
            _context = context;
            _getUserService = getUserService;
        }

        public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            try
            {
                // if role = admin, check if curr user is admin or not
                // ??????????????????????

                // check if there is this user (email) first
                var user = await _getUserService.GetUserByEmail(request.Email);
                if (user != null && user.Id != 0)
                {
                    // this email aldready registered
                    return new AddUserResponse("I01");
                }

                var hashedPassword = HashingPassword.HashPasword(request.Password, out var generatedSalt);

                using var transaction = _context.Database.BeginTransaction();
                User newUser = new()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EncryptedPassword = hashedPassword,
                    GeneratedSalt = generatedSalt,
                    RoleId = request.RoleId
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new AddUserResponse("S01");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
