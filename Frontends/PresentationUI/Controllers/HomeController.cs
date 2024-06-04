using DtoLayer.LocationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace PresentationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Location");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                List<SelectListItem> listLocation = (from x in values
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.LocationID
                                                     }).OrderBy(x => x.Text).ToList();
                ViewBag.Location = listLocation;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(string locationID, DateOnly pickUp_date, DateOnly dropOff_date, TimeOnly pickUp_time, TimeOnly dropOff_time)
        {
            return RedirectToAction("Index", "CarRental", new { locationID, pickUp_date, dropOff_date, pickUp_time, dropOff_time });
        }
    }
}
