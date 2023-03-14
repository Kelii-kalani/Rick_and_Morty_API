﻿using Microsoft.AspNetCore.Mvc;
using Rick_and_Morty_API.Models;
using Newtonsoft.Json;

namespace Rick_and_Morty_API.Controllers
{
    public class RickAndMortyController : Controller
    {
        public IActionResult Index()
        {
            var client = new HttpClient();

            var url = "https://rickandmortyapi.com/api/character";

            var response = client.GetStringAsync(url).Result;

            var root = JsonConvert.DeserializeObject<Root>(response);

            return View(root);
        }

        public IActionResult CharacterSearch()
        {
            var client = new HttpClient();

            var userInput = Console.ReadLine();

            var url = $"https://rickandmortyapi.com/api/character?name={userInput}";

            var response = client.GetStringAsync(url).Result;

            var root = JsonConvert.DeserializeObject<Root> (response);

            return View(root);
        }
    }
}
