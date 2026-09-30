namespace InventarioWebBE_FullStack.Models
{
    public class LostProduct
    {
        public int ID { get; set; }

        public required DateTime LostDate { get; set; } = DateTime.Now;

        public required int Quantity { get; set; }

        public required string DescriptionLost { get; set; } 



        public required Product Product { get; set; }

    }
}
