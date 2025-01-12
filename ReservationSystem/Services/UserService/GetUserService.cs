﻿using Microsoft.EntityFrameworkCore;
using ReservationSystem.API.Helpers.DataAccess;
using ReservationSystem.API.Helpers.Pagination;
using ReservationSystem.API.Models.Entities;
using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;
using ReservationSystem.API.Services.UserService.Interfaces;

namespace ReservationSystem.API.Services.UserService
{
    public class GetUserService : IGetUserService
    {
        private readonly DataContext _context;

        public GetUserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                var user = await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(s => s.Email == email);

                if (user == null)
                {
                    return new User();
                }

                return user;

                /*var detail = new UserModel() { 
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role.Description,
                };

                return new GetUserResponse("S01")
                {
                    UserDetail = detail
                };*/
            }
            catch (Exception)
            {
                return new User();
                throw;
            }
        }

        public async Task<GetUserResponse> GetUserById(int id)
        {
            try
            {
                var user = await _context.Users.Include(r => r.Role).FirstOrDefaultAsync(s => s.Id == id);

                if (user == null)
                {
                    return new GetUserResponse("I02");
                }

                var detail = new UserModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = user.Role.Description,
                };

                return new GetUserResponse("S01")
                {
                    UserDetail = detail
                };
            }
            catch (Exception)
            {
                return new GetUserResponse("E01");
                throw;
            }

            throw new NotImplementedException();
        }

        public async Task<GetUserListResponse> GetUserListByPageNo(GetUserListRequest request)
        {
            try
            {
                var users = await _context.Users.Include(r => r.Role).Page(request.PageNo, request.PageSize).ToListAsync();
                //var users = await _context.Users.Include(r => r.Role).ToListAsync();
                var rowCount = _context.Users.Count();

                if (users == null)
                {
                    return new GetUserListResponse("I02");
                }

                return new GetUserListResponse("S01")
                {
                    UserList = users.Select(s => new UserModel
                    {
                        Id = s.Id,
                        Email = s.Email,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Role = s.Role.Description,
                    }).ToList(),
                    TotalRow = rowCount,
                };
            }
            catch (Exception)
            {
                return new GetUserListResponse("E01");
                throw;
            }

            //throw new NotImplementedException();
        }
    }
}
