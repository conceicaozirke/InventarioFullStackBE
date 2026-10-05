using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class PurchaseOrderDTO
    {

        public required int PurchaseOrderOrderNumber { get; set; }

        public required decimal PurchaseOrderTotalPrice { get; set; }

        public decimal PurchaseOrderShippingCost { get; set; }

        public required decimal PurchaseOrderTaxes { get; set; }

        public required decimal PurchaseOrderProfit { get; set; }


        //InvoicePurchase

        public string InvoiceID { get; set; } = string.Empty;



    }
}
