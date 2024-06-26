using DtoLayer.CarDto;
using DtoLayer.CarPricingDto;
using DtoLayer.PricingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarPricingController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/CarPricing/ListCarPricingByCar?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingByCarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCarPricing()
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
                                                }).OrderBy(x => x.Text).ToList();

                ViewBag.Cars = listCar;
            }

            var response2 = await client.GetAsync("https://localhost:7210/api/Pricing");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);

                List<SelectListItem> listPricing = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.PricingID
                                                    }).ToList();

                ViewBag.Pricing = listPricing;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarPricing(CreateCarPricingDto createCarPricingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarPricingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/CarPricing", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CarPricing", new { area = "Administrator", id = createCarPricingDto.CarID });
            }
            return View();
        }

        public async Task<IActionResult> DeleteCarPricing(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/CarPricing?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCarPricing(string id)
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
                                                }).OrderBy(x => x.Text).ToList();

                ViewBag.Cars = listCar;
            }

            var response2 = await client.GetAsync("https://localhost:7210/api/Pricing");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData = await response2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);

                List<SelectListItem> listPricing = (from x in values
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.PricingID
                                                    }).ToList();

                ViewBag.Pricing = listPricing;
            }

            var response3 = await client.GetAsync("https://localhost:7210/api/CarPricing/GetCarPricing?id=" + id);
            if (response3.IsSuccessStatusCode)
            {
                var jsonData = await response3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarPricingDto>(jsonData);

                ViewBag.SelectedCar = values.CarID;
                ViewBag.SelectedPricing = values.PricingID;

                var carPricingViewModel = new CarPricingViewModel
                {
                    GetCarPricingDto = values
                };

                return View(carPricingViewModel);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCarPricing(UpdateCarPricingDto updateCarPricingDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarPricingDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/CarPricing", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "CarPricing", new { area = "Administrator", id = updateCarPricingDto.CarID });
            }
            return View();
        }
    }
}
