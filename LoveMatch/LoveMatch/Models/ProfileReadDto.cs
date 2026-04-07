using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveMatch.Models
{
    public class ProfileReadDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Bio { get; set; }
    }
}
