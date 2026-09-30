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

       
        
        
        
        public required Brand Brand { get; set; }
        public required PriceTag PriceTag { get; set; }
        public required InvoicePurchase InvoicePurchase { get; set; }



    }
}
