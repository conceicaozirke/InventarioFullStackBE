using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class SellingOrderRequest
    {

        public int SellingOrderID { get; set; }

        public required int SellingOrderOrderNumber { get; set; }

        public required decimal SellingOrderTotalPrice { get; set; }

        public required decimal SellingOrderShippingCost { get; set; }

        public required decimal SellingOrderTaxes { get; set; }

        public required decimal SellingOrderProfit { get; set; }


        //Invoice sold

        public int InvoiceID { get; set; }
                
    }
}
