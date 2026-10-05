using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class BoughtProductDTO
    {

        public required int Quantity { get; set; }

        public int ShippingCost { get; set; }
        public required int Taxes { get; set; }

        //Product

        public string ProductID { get; set; } = string.Empty;


        //InvoiceSold
        public string InvoicePurchaseID { get; set; } = string.Empty;


      


    }
}
