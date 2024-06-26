using DtoLayer.ServiceDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class ServicesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ServicesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Service");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(services);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createServiceDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Services", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteService(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/Service?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Services", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Service/GetService?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<GetServiceDto>(jsonData);

                var serviceViewModel = new ServiceViewModel
                {
                    GetServiceDto = service
                };
                return View(serviceViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateServiceDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/Service", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Services", new { area = "Administrator" });
            }
            return View();
        }
    }
}
