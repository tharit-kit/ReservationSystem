using Microsoft.AspNetCore.Mvc;

namespace ReservationSystem.Controllers
{
    public class OwnerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
