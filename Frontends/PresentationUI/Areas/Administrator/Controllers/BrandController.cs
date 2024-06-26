using DtoLayer.BrandDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BrandController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Brand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var brands = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(brands);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createBrandDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7210/api/Brand", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7210/api/Brand?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7210/api/Brand/GetBrand?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var brand = JsonConvert.DeserializeObject<GetBrandDto>(jsonData);

                var brandViewModel = new BrandViewModel
                {
                    GetBrandDto = brand
                };
                return View(brandViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateBrandDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7210/api/Brand", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Brand", new { area = "Administrator" });
            }
            return View();
        }
    }
}
