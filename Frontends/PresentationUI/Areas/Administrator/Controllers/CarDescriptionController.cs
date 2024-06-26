using DtoLayer.CarDescriptionDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CarDescriptionController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarDescriptionController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index(string id)
        {
            ViewBag.CarId = id;

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarDescription/ListCarDescriptionByCar?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarDescriptionDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCarDescription(string id)
        {
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarDescription(CreateCarDescriptionDto createCarDescriptionDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDescriptionDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/CarDescription", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteDescription(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/CarDescription?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDescription(string id, string car)
        {
            ViewBag.CarId = car;

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarDescription/GetCarDescription?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarDescriptionDto>(jsonData);

                var carDescription = new CarDescriptionViewModel
                {
                    GetCarDescriptionDto = values
                };

                return View(carDescription);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDescription(UpdateCarDescriptionDto updateCarDescriptionDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDescriptionDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/CarDescription", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }
    }
}
