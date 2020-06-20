namespace Projekt_s16696.Models
{
    public class Banner
    {
        public int IdAdvertisement { get; set; }

        public int Name { get; set; }

        public decimal Price { get; set; }

        public int IdCampaign { get; set; }

        public decimal Area { get; set; }


        public virtual Campaign Campaign { get; set; }
    }
}