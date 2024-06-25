using DtoLayer.CarDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.CarDetail
{
    public class CarDetail : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarDetail(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Car/GetCarWithBrand?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarWithBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
