using DtoLayer.StatisticDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.Home
{
    public class Statistic : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public Statistic(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7210/api/Statistic/GetCarCount");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetCarCountDto>(jsonData);

            ViewBag.CarCount = values.CarCount;

            var response2 = await client.GetAsync("https://localhost:7210/api/Statistic/GetBrandCount");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetBrandCountDto>(jsonData2);

            ViewBag.BrandCount = values2.BrandCount;

            var response3 = await client.GetAsync("https://localhost:7210/api/Statistic/GetLocationCount");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<GetLocationCountDto>(jsonData3);

            ViewBag.LocationCount = values3.LocationCount;

            return View();
        }
    }
}
