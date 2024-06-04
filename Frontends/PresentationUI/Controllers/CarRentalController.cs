using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class CarRentalController : Controller
    {
        public IActionResult Index(string id)
        {
            return View();
        }
    }
}
