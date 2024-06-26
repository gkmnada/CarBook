using DtoLayer.FeatureDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public FeatureController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Feature");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var features = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(data);
                return View(features);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createFeatureDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Feature", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/Feature?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Feature/GetFeature?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var feature = JsonConvert.DeserializeObject<GetFeatureDto>(data);

                var featureViewModel = new FeatureViewModel
                {
                    GetFeatureDto = feature
                };
                return View(featureViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateFeatureDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/Feature", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Administrator" });
            }
            return View();
        }
    }
}

