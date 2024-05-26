using DtoLayer.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public MessageController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(messages);
            }
            return View();
        }
    }
}
