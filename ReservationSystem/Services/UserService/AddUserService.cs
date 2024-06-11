using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Helpers.DataAccess;
using ReservationSystem.Models.Bases;
using ReservationSystem.Models.Entities;
using ReservationSystem.Models.Requests;
using ReservationSystem.Models.Responses;
using ReservationSystem.Services.UserService.Interfaces;

namespace ReservationSystem.Services.UserService
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
                // check if there is this user (email) first
                var userDetail = await _getUserService.GetUserByEmail(request.Email);
                if (userDetail.Id != 0)
                {
                    // this email aldready registered
                }

                using var transaction = _context.Database.BeginTransaction();
                User user = new()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    EncryptedPassword = request.Password,
                    RoleId = request.RoleId
                };
                
                _context.Users.Add(user);
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
