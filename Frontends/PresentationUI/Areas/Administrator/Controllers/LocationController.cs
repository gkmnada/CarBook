using DtoLayer.LocationDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class LocationController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public LocationController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Location");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var locations = JsonConvert.DeserializeObject<List<ResultLocationDto>>(data);
                return View(locations);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createLocationDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Location", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteLocation(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/Location?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Location/GetLocation?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var location = JsonConvert.DeserializeObject<GetLocationDto>(data);

                var locationViewModel = new LocationViewModel
                {
                    GetLocationDto = location
                };
                return View(locationViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateLocationDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/Location", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Location", new { area = "Administrator" });
            }
            return View();
        }
    }
}