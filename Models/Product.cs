namespace InventarioWebBE_FullStack.Models
{
    public class Product
    {
        public string ID { get; set; } = string.Empty;

        public required string ProductName { get; set; } 

        public int Quantity { get; set; }

        public  string?  Notes { get; set; }

        public DateTime CreatedAt { get; set; } =DateTime.Now;

        public DateTime LastUpdatedAt {  get; set; } =DateTime.Now;

        public int BrandID { get; set; }
        public int PriceTagID { get; set; }
        public string? InvoicePurchaseID { get; set; }
        public int PriceBoughtID { get; set; }



        public  Brand? Brand { get; set; }
        public  PriceTag? PriceTag { get; set; }
        public InvoicePurchase? InvoicePurchase { get; set; }

        public PriceBought? PriceBought { get; set; }

    }
}
