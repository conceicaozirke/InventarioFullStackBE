namespace InventarioWebBE_FullStack.DTO
{
    public class DocumentTypeRequest
    {

        public int DocumentTypeID { get; set; }

        public string DocumentTypeName { get; set; } = string.Empty;

        public string? DocumentTypeNotes { get; set; }

    }
}
