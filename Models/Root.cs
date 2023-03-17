using Microsoft.AspNetCore.Mvc;

namespace Rick_and_Morty_API.Models
{
    public class Root
    {
        public Info? Info { get; set; }
        public List<ResultsItem>? Results { get; set; }
    }
}
