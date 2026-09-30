namespace InventarioWebBE_FullStack.Models

{
    public class Brand
    {
        public int ID { get; set; }

        public required string Name { get; set; }

        public required string Adress { get; set; }

        public string? Notes { get; set; } 

        public int DocumentNumber { get; set; }

        public required DocumentType DocumentType { get; set; }






    }
}
