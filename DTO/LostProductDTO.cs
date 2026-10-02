using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class LostProductDTO
    {
        //LostProducts

        public required DateTime LostProductDate { get; set; } = DateTime.Now;

        public required int LostProductQuantity { get; set; }

        public required string LostNotes { get; set; }


        //Product
        public string ProductID { get; set; } = string.Empty;


    }

    

}
