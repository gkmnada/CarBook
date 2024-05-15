using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
