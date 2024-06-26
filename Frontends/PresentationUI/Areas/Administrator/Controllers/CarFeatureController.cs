using DtoLayer.CarDto;
using DtoLayer.CarFeatureDto;
using DtoLayer.FeatureDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarFeatureController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarFeature?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var carFeature = JsonConvert.DeserializeObject<List<ResultCarFeatureDto>>(jsonData);
                return View(carFeature);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureDto> resultCarFeatureDto)
        {
            foreach (var item in resultCarFeatureDto)
            {
                var client = _clientFactory.CreateClient();

                if (item.Available)
                {
                    var response = await client.GetAsync("https://localhost:7210/api/CarFeature/UpdateAvailableToTrue?id=" + item.CarFeatureID);
                }
                else
                {
                    var response = await client.GetAsync("https://localhost:7210/api/CarFeature/UpdateAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "Cars", new { area = "Administrator", });
        }

        [HttpGet]
        public async Task<IActionResult> CreateCarFeature()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Car/ListCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);

                List<SelectListItem> listCar = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.BrandName + ' ' + x.Model,
                                                    Value = x.CarID
                                                }).ToList();

                ViewBag.Cars = listCar;
            }

            var response2 = await client.GetAsync("https://localhost:7210/api/Feature");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                List<SelectListItem> listFeature = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.FeatureName,
                                                        Value = x.FeatureID
                                                    }).ToList();

                ViewBag.Features = listFeature;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarFeature(CreateCarFeatureDto createCarFeatureDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarFeatureDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/CarFeature", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CreateCarFeature", "CarFeature", new { area = "Administrator" });
            }
            return View();
        }
    }
}
