using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Models.Requests;
using ReservationSystem.Services.UserService;

namespace ReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        AddUserService _addUserService;
        public AdminController(AddUserService addUserService) 
        { 
            _addUserService = addUserService;
        }

        /*public IActionResult AddUser([FromBody] AddUserRequest request)
        {

        }*/
    }
}
