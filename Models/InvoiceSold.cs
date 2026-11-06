namespace InventarioWebBE_FullStack.Models
{
    public class InvoiceSold
    {
        public string  ID { get; set; } = string.Empty;

        public string InvoiceNumber { get; set; }=string.Empty;
        public DateTime SellingDate { get; set; } = DateTime.Now;

        public required decimal PriceTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal ShippingCost { get; set; }

        public string SellingStatus { get; set; } = string.Empty;

        public bool SellingConfirmed { get; set; } = false;
        public bool IsDeleted { get; set; } = false;


    }
}
