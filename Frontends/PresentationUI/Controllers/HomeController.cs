using DtoLayer.CarRentalDto;
using DtoLayer.LocationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> Index(CreateCarRentalDto createCarRentalDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createCarRentalDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/CarRental", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarRentalDto>>(jsonData);
                var id = values.Select(x => x.CarID).FirstOrDefault();
                return RedirectToAction("Index", "CarRental", new { id });
            }
            return View();
        }
    }
}
