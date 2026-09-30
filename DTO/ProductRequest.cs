using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class ProductRequest
    {
        public string ProductID { get; set; } = string.Empty;

        public required string Product_ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public string? ProductNotes { get; set; }

        public DateTime ProductCreatedAt { get; set; } = DateTime.Now;

        public DateTime ProductLastUpdatedAt { get; set; } = DateTime.Now;




        //Brand

        public int BrandID { get; set; }

        public required string BrandName { get; set; }


        //Pricetag
        public int PricetagID { get; set; }

        //Pricebought
        public int PriceboughtID {get;set;}

        //PriceMargin
        public int PriceMarginID { get;set;}


        //InvoicePurchase
        public int InvoicePurchaseID {get;set;}



    }
}
