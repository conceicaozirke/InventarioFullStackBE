using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class PriceTagRequest
    {
        public int ID { get; set; }

        public decimal Pricetag_Pricetag { get; set; }

        public decimal PricetagTotalCosts { get; set; }

        public DateTime PricetagPriceWhen { get; set; } = DateTime.UtcNow;

        

        //PriceBought
        public int PriceBoughtID { get; set; }

        public decimal PriceBoughtUnitPrice { get; set; }
        public decimal PriceBoughtShippingCost { get; set; }
        public decimal PriceBoughtTaxes { get; set; }



        //PriceMargin

        public int MarginID { get; set; }
        public  string MarginProductName { get; set; } = string.Empty;
                
        public float MarginProp { get; set; }





    }
}
