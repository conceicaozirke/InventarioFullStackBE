using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class PriceTagDTO
    {
        public int ID { get; set; }

        public decimal Pricetag_Pricetag { get; set; }

        public decimal PricetagTotalCosts { get; set; }

        public DateTime PricetagPriceWhen { get; set; } = DateTime.UtcNow;

        public required decimal PriceTagProfit { get; set; }


        //PriceBought
        public int PriceBoughtID { get; set; }


        //PriceMargin

        public int MarginID { get; set; }
       





    }
}
