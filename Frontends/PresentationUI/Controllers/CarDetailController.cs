using Microsoft.AspNetCore.Mvc;

namespace PresentationUI.Controllers
{
    public class CarDetailController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarDetailController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
