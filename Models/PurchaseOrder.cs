using System.Net;

namespace InventarioWebBE_FullStack.Models
{
    public class PurchaseOrder
    {
        public int ID { get; set; }

        public required int OrderNumber { get; set; } 

        public required decimal TotalPrice { get; set; }

        public decimal ShippingCost { get; set; }

        public required decimal Taxes { get; set; }    

        public required decimal Profit { get; set; }


        public required InvoicePurchase InvoicePurchase { get; set; }
    }
}
