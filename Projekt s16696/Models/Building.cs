using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_s16696.Models
{
    public class Building
    {
        public int IdBuilding { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string City { get; set; }

        public decimal Height { get; set; }

        public virtual ICollection<Campaign> Campaings { get; set; }

        public virtual ICollection<Campaign> FromIdBuild { get; set; }

        public virtual ICollection<Campaign> ToIdBuild { get; set; }

    }
}
