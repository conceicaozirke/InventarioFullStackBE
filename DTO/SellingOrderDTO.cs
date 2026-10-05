using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class SellingOrderDTO
    {

        public required int SellingOrderOrderNumber { get; set; }

        public required decimal SellingOrderTotalPrice { get; set; }

        public required decimal SellingOrderShippingCost { get; set; }

        public required decimal SellingOrderTaxes { get; set; }

        public required decimal SellingOrderProfit { get; set; }


        //Invoice sold

        public string InvoiceID { get; set; } = string.Empty;
                
    }
}
