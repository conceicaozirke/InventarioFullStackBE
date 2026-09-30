namespace InventarioWebBE_FullStack.Models
{
    public class InvoiceSold
    {
        public int ID { get; set; }

        public DateTime SellingDate { get; set; } = DateTime.Now;

        public required decimal PriceTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal ShippingCost { get; set; }

        public string SellingStatus { get; set; } = string.Empty;

        public bool SellingConfirmed { get; set; } = false;


    }
}
