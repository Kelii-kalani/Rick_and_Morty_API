using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index1(int num)
        {
            var client = new HttpClient();

            var url = $"https://rickandmortyapi.com/api/character/page={num}";

            var response = client.GetStringAsync(url).Result;

            var info = JsonConvert.DeserializeObject<Info>(response);

            return View(info);
        }
    }
}
