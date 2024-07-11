using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.Requests.User;
using ReservationSystem.Services.MasterService.Interface;
using ReservationSystem.Services.UserService;
using ReservationSystem.Services.UserService.Interfaces;

namespace ReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {
        IGetMasterService _getMasterService;

        public MasterController(IGetMasterService getMasterService)
        {
            _getMasterService = getMasterService;
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetUsersByPageNo()
        {
            try
            {
                var roles = await _getMasterService.GetRoles();

                return Ok(roles);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
