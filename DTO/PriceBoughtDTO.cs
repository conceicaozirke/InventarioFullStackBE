using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class PriceBoughtDTO
    {


        public decimal PriceBoughtUnityPrice { get; set; }
        public decimal PriceBoughtShippingCost { get; set; }
        public decimal PriceBoughtTaxes { get; set; }

        public string InvoicePurchaseID { get; set; } = string.Empty;
       
    }
}
