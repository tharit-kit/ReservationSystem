using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.API.Models.Requests.User;
using ReservationSystem.API.Models.Responses.User;
using ReservationSystem.API.Services.UserService.Interfaces;

namespace ReservationSystem.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "RequireAdministratorRole")]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAddUserService _addUserService;
        private readonly IGetUserService _getUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IUpdateUserService _updateUserService;

        public AdminController(IAddUserService addUserService, IGetUserService getUserService, IDeleteUserService deleteUserService, IUpdateUserService updateUserService)
        {
            _addUserService = addUserService;
            _getUserService = getUserService;
            _deleteUserService = deleteUserService;
            _updateUserService = updateUserService;
        }

        //[Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsersByPageNo([FromQuery] GetUserListRequest request)
        {
            try
            {
                var users = await _getUserService.GetUserListByPageNo(request);
                if (users == null)
                {
                    return BadRequest(users);
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUsersById([FromRoute] int id)
        {
            try
            {
                var user = await _getUserService.GetUserById(id);
                if (user == null)
                {
                    return BadRequest(user);
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddNewUser([FromBody] AddUserRequest request)
        {
            try
            {
                var newUser = await _addUserService.AddUser(request);
                if (newUser == null)
                {
                    return BadRequest(newUser);
                }

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult<GetUserListResponse>> RomoveUserById([FromRoute] int id)
        {
            try
            {
                var user = await _deleteUserService.DeleteUserById(id);

                if (user == null)
                {
                    return BadRequest(user);
                }

                return Created();
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

        [HttpPut("users/{id}")]
        public async Task<ActionResult<GetUserListResponse>> UpdateUserById([FromRoute] int id, [FromBody] UpdateUserRequest request)
        {
            try
            {
                var user = await _updateUserService.UpdateUserById(id, request);

                if (user == null)
                {
                    return BadRequest(user);
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }
    }
}
