using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class PurchaseOrderRequest
    {
        public int PurchaseOrderID { get; set; }

        public required int PurchaseOrderOrderNumber { get; set; }

        public required decimal PurchaseOrderTotalPrice { get; set; }

        public decimal PurchaseOrderShippingCost { get; set; }

        public required decimal PurchaseOrderTaxes { get; set; }

        public required decimal PurchaseOrderProfit { get; set; }


        //InvoicePurchase

        public string InvoiceID { get; set; } = string.Empty;

        public required int InvoiceNumber { get; set; }

       public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public decimal PriceTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal ShippingCost { get; set; }

        public string PurchaseStatus { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = false;


    }
}
