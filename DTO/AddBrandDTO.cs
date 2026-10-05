using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class AddBrandDTO
    {

        public string BrandName { get; set; } = string.Empty;

        public string? BrandNotes { get; set; }

        public string BrandAdress { get; set; } = string.Empty;

        public string BrandDocumentNumber { get; set; } = string.Empty;

        public int BrandDocumentTypeID { get; set; } 

    }
}
