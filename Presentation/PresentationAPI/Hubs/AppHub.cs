using Application.Features.Mediator.Results.ReviewResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace PresentationAPI.Hubs
{
    public class AppHub : Hub
    {
        private readonly IHttpClientFactory _clientFactory;

        public AppHub(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task SendReviewCount(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Review/GetReviewCountByCar?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetReviewCountByCarQueryResult>(jsonData);
                await Clients.All.SendAsync("ReceiveReviewCount", values.ReviewCount);
            }
        }
    }
}
