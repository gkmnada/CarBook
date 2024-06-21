using DtoLayer.AboutDto;
using DtoLayer.StatisticDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AboutController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);

                var responseMessage2 = await client.GetAsync("https://localhost:7210/api/Statistic/GetCarCount");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<GetCarCountDto>(jsonData2);

                ViewBag.CarCount = values2.CarCount;

                var responseMessage3 = await client.GetAsync("https://localhost:7210/api/Statistic/GetBrandCount");
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<GetBrandCountDto>(jsonData3);

                ViewBag.BrandCount = values3.BrandCount;

                var responseMessage4 = await client.GetAsync("https://localhost:7210/api/Statistic/GetLocationCount");
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<GetLocationCountDto>(jsonData4);

                ViewBag.LocationCount = values4.LocationCount;

                return View(values);
            }
            return View();
        }
    }
}
