using DtoLayer.CarDescriptionDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.CarDetail
{
    public class CarDescription : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarDescription(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarDescription/GetCarDescriptionByCar?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarDescriptionDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
