namespace InventarioWebBE_FullStack.DTO
{
    public class SoldInvoiceRequest
    {

        public int InvoiceSoldID { get; set; }

        public DateTime InvoiceSoldSellingDate { get; set; } = DateTime.Now;

        public required decimal InvoiceSoldPriceTotal { get; set; }

        public decimal InvoiceSoldTaxTotal { get; set; }

        public decimal InvoiceSoldShippingCost { get; set; }

        public string InvoiceSoldStatus { get; set; } = string.Empty;

        public bool InvoiceSoldConfirmed { get; set; } = false;



    }
}
