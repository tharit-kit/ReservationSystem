using Microsoft.AspNetCore.Mvc;

namespace ReservationSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
