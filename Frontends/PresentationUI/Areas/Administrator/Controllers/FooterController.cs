using DtoLayer.FooterDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class FooterController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public FooterController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Footer");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFooter()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooter(CreateFooterDto createFooterDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createFooterDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7210/api/Footer", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Footer", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteFooter(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7210/api/Footer?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Footer", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFooter(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Footer/GetFooter?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetFooterDto>(jsonData);

                var footerViewModel = new FooterViewModel
                {
                    GetFooterDto = values
                };
                return View(footerViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooter(UpdateFooterDto updateFooterDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateFooterDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7210/api/Footer", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Footer", new { area = "Administrator" });
            }
            return View();
        }
    }
}
