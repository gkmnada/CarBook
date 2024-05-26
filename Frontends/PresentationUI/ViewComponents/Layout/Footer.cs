using DtoLayer.FooterDto;
using DtoLayer.SocialMediaDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.Layout
{
    public class Footer : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public Footer(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Footer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);

                var response = await client.GetAsync("https://localhost:7210/api/SocialMedia");
                var json = await response.Content.ReadAsStringAsync();
                var socialMedia = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(json);

                ViewBag.SocialMedia = socialMedia;

                return View(values);
            }
            return View();
        }
    }
}
