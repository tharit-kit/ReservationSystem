using Microsoft.AspNetCore.Mvc;
using ReservationSystem.API.Services.MasterService.Interface;
using ReservationSystem.Models.Requests.User;
using ReservationSystem.Models.Responses.Role;
using ReservationSystem.Services.UserService;
using ReservationSystem.Services.UserService.Interfaces;

namespace ReservationSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        IGetMasterService _getMasterService;

        public MasterController(IGetMasterService getMasterService)
        {
            _getMasterService = getMasterService;
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _getMasterService.GetRoles();

                if (roles == null)
                {
                    return Ok(new GetRoleListResponse("S02"));
                }

                return Ok(new GetRoleListResponse("S01")
                {
                    RoleList = roles.Select(s => new RoleModel
                    {
                        Id = s.Id,
                        Description = s.Description,
                    }).ToList(),
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new GetRoleListResponse("E01"));
                throw;
            }
        }
    }
}
