using DtoLayer.PricingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PricingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Pricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(data);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreatePricing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDto createPricingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7210/api/Pricing", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Pricing", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeletePricing(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7210/api/Pricing?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Pricing", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricing(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Pricing/GetPricing?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetPricingDto>(jsonData);

                var pricingViewModel = new PricingViewModel
                {
                    GetPricingDto = values
                };
                return View(pricingViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDto updatePricingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePricingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7210/api/Pricing", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Pricing", new { area = "Administrator" });
            }
            return View();
        }
    }
}
