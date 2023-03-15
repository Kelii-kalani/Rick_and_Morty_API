﻿using Microsoft.AspNetCore.Mvc;
using Rick_and_Morty_API.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace Rick_and_Morty_API.Controllers
{
    
    public class RickAndMortyController : Controller
    {
        public IActionResult Index([FromQuery(Name = "resource_url")] string resourceUrl = "https://rickandmortyapi.com/api/character")
        {
            if (resourceUrl.StartsWith("https://rickandmortyapi.com"))
            {
                var client = new HttpClient();

                var url = resourceUrl;

                var response = client.GetStringAsync(url).Result;

                var root = JsonConvert.DeserializeObject<Root>(response);

                return View(root);
            }
            else
            {
                return View("Page invalid");
            }
        }
    }
}
