using System;
using System.Collections;
using System.Collections.Generic;

namespace Projekt_s16696.Models
{
    public class Campaign 
    {
        public int IdCampaign { get; set; }

        public int IdClient { get; set; }
        public virtual Client Client { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PricePerSquareMeter { get; set; }

        public int FromIdBuilding { get; set; }

        public int ToIdBuilding { get; set; }

        public virtual Building Building_1 { get; set; }

        public virtual Building Building_2 { get; set; }

        public virtual ICollection<Banner> Banners { get; set; }

    }
}