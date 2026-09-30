namespace InventarioWebBE_FullStack.Models
{
    public class PriceMargin
    {
        public int ID { get; set; }
        public required string ProductName { get; set; } = string.Empty;
        
        public string? Notes { get; set; }

        public float MarginProp { get; set; }



    }
}
