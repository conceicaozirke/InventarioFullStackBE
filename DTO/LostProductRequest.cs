using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class LostProductRequest
    {
        //LostProducts
        public int LostProductID { get; set; }

        public required DateTime LostProductDate { get; set; } = DateTime.Now;

        public required int LostProductQuantity { get; set; }

        public required string LostProductNotes { get; set; }


        //Product
        public string ProductID { get; set; } = string.Empty;

        public required string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public DateTime ProductUpdated{ get; set; } = DateTime.Now;



        //brand
        public int BrandID { get; set; }

        //PriceTag
        public required Models.PriceTag PriceTag { get; set; }

        //InvoicePurchase
        public required InvoicePurchase InvoicePurchase { get; set; }





    }
}
