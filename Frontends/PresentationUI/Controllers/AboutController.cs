using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
