



namespace InventarioWebBE_FullStack.Models



{
    public class DocumentType
    {
     public int ID { get; set; }

    public required string Name { get; set; } =string.Empty;

    public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } =DateTime.Now;


    }
}
