using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class PriceBoughtRequest
    {

        public int PriceBoughtID { get; set; }

        public decimal PriceBoughtUnityPrice { get; set; }
        public decimal PriceBoughtShippingCost { get; set; }
        public decimal PriceBoughtTaxes { get; set; }

       
        //InvoicePurchase
        public string InvoicePurchaseID { get; set; } = string.Empty;
       
    }
}
