using Microsoft.AspNetCore.Mvc;

namespace Rick_and_Morty_API.Models
{
    public class Info
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string? Next { get; set; }
        public string? Prev { get; set; }
    }
}
