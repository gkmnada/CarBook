using DtoLayer.ReviewDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.ViewComponents.CarDetail
{
    public class CarReview : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarReview(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.Id = id;

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Review?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReviewDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
