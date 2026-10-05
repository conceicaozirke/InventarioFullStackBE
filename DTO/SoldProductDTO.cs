using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class SoldProductDTO
    {

        public required int QuantitySold { get; set; }

        public int ShippingCost { get; set; }
        public required int Taxes { get; set; }
        public required int Profit { get; set; }


        //Product

        public string ProductID { get; set; } = string.Empty;


        //InvoiceSold
        public string InvoiceSoldID { get; set; } = string.Empty;


      


    }
}
