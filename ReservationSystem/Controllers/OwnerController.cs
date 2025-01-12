using Microsoft.AspNetCore.Mvc;

namespace ReservationSystem.API.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
