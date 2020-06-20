using Projekt_s16696.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_s16696.DTOs
{
    public class CampaignResponse
    {
        public int IdCampaign { get; set; }

        public int IdClient { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public decimal PricePerSquareMeter { get; set; }

        public int FromIdBuilding { get; set; }

        public int ToIdBuilding { get; set; }

        public virtual ICollection<Banner> Banners { get; set; }
    }
}
