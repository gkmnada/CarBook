﻿using DtoLayer.AboutDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PresentationUI.Areas.Administrator.Models;
using System.Text;

namespace PresentationUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Administrator")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AboutController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createAboutDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7210/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Administrator" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7210/api/About?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Administrator" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/About/GetAbout?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAboutDto>(jsonData);

                var aboutViewModel = new AboutViewModel
                {
                    GetAboutDto = values
                };
                return View(aboutViewModel);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateAboutDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7210/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Administrator" });
            }
            return View();
        }
    }
}
