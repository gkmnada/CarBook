using DtoLayer.BannerDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.Home
{
    public class Banner : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public Banner(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var repsonseMessage = await client.GetAsync("https://localhost:7210/api/Banner");
            if (repsonseMessage.IsSuccessStatusCode)
            {
                var jsonData = await repsonseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
