using DtoLayer.LocationDto;
using DtoLayer.ReservationDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace PresentationUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReservationController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string id)
        {
            ViewBag.CarID = id;

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
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7210/api/Reservation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
