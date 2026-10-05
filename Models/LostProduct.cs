namespace InventarioWebBE_FullStack.Models
{
    public class LostProduct
    {
        public int ID { get; set; }

        public required DateTime LostDate { get; set; } = DateTime.Now;

        public required int Quantity { get; set; }

        public required string Notes { get; set; } 
         
        public string ProductID { get; set; } = string.Empty;

        public Product? Product { get; set; }


    }
}
