using DtoLayer.CarPricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Controllers
{
    public class CarRentalController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarRentalController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string locationID)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/CarPricing/ListCarPricingWithCarRental?locationID=" + locationID);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarRentalDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
