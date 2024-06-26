using DtoLayer.BrandDto;
using DtoLayer.CarDto;
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
    public class CarsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CarsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Car/ListCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Brand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);

                List<SelectListItem> listBrand = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.BrandName,
                                                      Value = x.BrandID
                                                  }).ToList().OrderBy(x => x.Text).ToList();

                ViewBag.Brands = listBrand;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Car", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteCar(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/Car?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Car/GetCar?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCarDto>(jsonData);

                var responseMessage = await client.GetAsync("https://localhost:7210/api/Brand");
                var json = await responseMessage.Content.ReadAsStringAsync();
                var brand = JsonConvert.DeserializeObject<List<ResultBrandDto>>(json);

                List<SelectListItem> listBrand = (from x in brand
                                                  select new SelectListItem
                                                  {
                                                      Text = x.BrandName,
                                                      Value = x.BrandID
                                                  }).ToList().OrderBy(x => x.Text).ToList();

                ViewBag.Brands = listBrand;

                ViewBag.SelectedBrand = values.BrandID;
                ViewBag.SelectedTransmission = values.Transmission;
                ViewBag.SelectedFuel = values.Fuel;

                var carViewModel = new CarViewModel
                {
                    GetCarDto = values
                };
                return View(carViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/Car", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Cars", new { area = "Administrator" });
            }
            return View();
        }
    }
}
