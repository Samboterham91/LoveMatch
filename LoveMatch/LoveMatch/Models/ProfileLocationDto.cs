using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveMatch.Models
{
    public class ProfileLocationDto
    // Tim 12-04-2026: Deze DTO (Data Transfer Object) wordt gebruikt om de locatiegegevens van een profiel bij te werken.
    {
        public double Latitude { get; set; }
          public double Longitude { get; set; }
        
    }
}
