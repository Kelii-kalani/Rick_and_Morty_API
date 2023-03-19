using Microsoft.AspNetCore.Mvc;
using Rick_and_Morty_API.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;

namespace Rick_and_Morty_API.Controllers
{

    public class RickAndMortyController : Controller
    {
        private readonly ILogger<RickAndMortyController> _logger;

        public RickAndMortyController(ILogger<RickAndMortyController> logger)
        {
            _logger = logger;
        }

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
                return View("Invalid Page");
            }
        }

        public IActionResult CallName(string name)
        {
            var client = new HttpClient();

            var url = $"https://rickandmortyapi.com/api/character/?name={name}";

            var response = client.GetStringAsync(url).Result;

            var resultsItem = JsonConvert.DeserializeObject<Root>(response);

            return View(resultsItem);

        }
    }
}