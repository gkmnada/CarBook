using DtoLayer.CarPricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Controllers
{
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PricingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarPricing/ListCarPricingWithPeriod");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithPeriodDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
