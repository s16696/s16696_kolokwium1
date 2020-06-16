using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium_2.DTOs
{
    public class PlayerDtos
    {
        public string firstName { get; set; }
        public string lastname { get; set; }
        public DateTime birthdate { get; set; }
        public int numOnShirt { get; set; }
        public string comment { get; set; }
    }
}
