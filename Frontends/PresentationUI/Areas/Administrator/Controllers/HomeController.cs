using DtoLayer.StatisticDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7210/api/Statistic/GetCarCount");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage1.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarCountDto>(jsonData);
                ViewBag.CarCount = values?.CarCount;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7210/api/Statistic/GetBrandCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBrandCountDto>(jsonData);
                ViewBag.BrandCount = values?.BrandCount;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7210/api/Statistic/GetCarByDailyMinPrice");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarByDailyMinPriceDto>(jsonData);
                ViewBag.GetCarByDailyMinPrice = values?.CarName;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7210/api/Statistic/GetCarByDailyMaxPrice");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarByDailyMaxPriceDto>(jsonData);
                ViewBag.GetCarByDailyMaxPrice = values?.CarName;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7210/api/Statistic/GetDailyAveragePricing");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetDailyAveragePricingDto>(jsonData);
                ViewBag.GetDailyAveragePricing = Math.Round(values.DailyAveragePricing, 2);
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7210/api/Statistic/GetBrandNameByMostCar");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBrandNameByMostCarDto>(jsonData);
                ViewBag.GetBrandNameByMostCar = values?.BrandName;
            }
            return View();
        }
    }
}
