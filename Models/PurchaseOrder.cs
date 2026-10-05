using System.Net;

namespace InventarioWebBE_FullStack.Models
{
    public class PurchaseOrder
    {
        public string ID { get; set; } = string.Empty;

        public required int OrderNumber { get; set; } 

        public required decimal TotalPrice { get; set; }

        public decimal ShippingCost { get; set; }

        public required decimal Taxes { get; set; }    

        public required decimal Profit { get; set; }

        public string InvoicePurchaseID { get; set; }=string.Empty;

        public DateTime CreatedAt { get; set; }=DateTime.Now;


        public  InvoicePurchase? InvoicePurchase { get; set; }


    }
}
