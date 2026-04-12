using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveMatch.Models
{
    public class ProfileCreateDto
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Bio { get; set; }
        public required string City { get; set; } // Tim 12-04-2026: Locatie gegevens toegevoegd voor OpenFreeMaps API
    }
}
