using DtoLayer.CarFeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarFeatureController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarFeature?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var carFeature = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
                return View(carFeature);
            }
            return View();
        }
    }
}
