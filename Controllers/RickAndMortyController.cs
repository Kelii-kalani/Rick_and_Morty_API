using Microsoft.AspNetCore.Mvc;
using Rick_and_Morty_API.Models;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

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

        public IActionResult CallName()
        {
            var client = new HttpClient();

            string name = Console.ReadLine();

            var url = $"https://rickandmortyapi.com/api/character/?name={name}";

            var response = client.GetStringAsync(url).Result;

            var api = JsonConvert.DeserializeObject<ResultsItem>(response);

            //var characterName = api.Name;
            //var species = api.Species;
            //var gender = api.Gender;
            //var type = api.Type;
            //var status = api.Status;
            //var image = api.Image;

            return View(api);

        }
    }
}