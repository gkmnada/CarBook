using DtoLayer.CarPricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Controllers
{
    public class CarsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/CarPricing/ListCarPricingWithCar");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
