using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class CreateNewBrandRequest
    {
        public int ID { get; set; }

        public int BrandID { get; set; }

        public string BrandName { get; set; } = string.Empty;

        public string? BrandNotes { get; set; } 

        public int BrandDocumentNumber { get; set; }

        public string BrandDocumentType { get; set; } = string.Empty;

    }
}
