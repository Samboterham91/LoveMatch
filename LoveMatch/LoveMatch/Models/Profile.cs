using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveMatch.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Bio { get; set; }

        // Tim 12-04-2026: Locatie gegevens toegevoegd voor OpenFreeMaps API
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? City { get; set; }
    }
}
