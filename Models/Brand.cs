namespace InventarioWebBE_FullStack.Models

{
    public class Brand
    {
        public int ID { get; set; }

        public required string Name { get; set; }

        public required string Adress { get; set; }

        public string? Notes { get; set; } 

        public string DocumentNumber { get; set; } = string.Empty;

        public required DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int DocumentTypeID { get; set; }

        public  DocumentType? DocumentType { get; set; }






    }
}
