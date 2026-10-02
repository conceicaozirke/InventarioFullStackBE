using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class ProductDTO
    {

        public required string Product_ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public string? ProductNotes { get; set; }

        public DateTime ProductCreatedAt { get; set; } = DateTime.Now;

        public DateTime ProductLastUpdatedAt { get; set; } = DateTime.Now;




        //Brand

        public int BrandID { get; set; }

        //Pricetag
        public int PricetagID { get; set; }

        //Pricebought
        public int PriceboughtID {get;set;}

        //PriceMargin
        public int PriceMarginID { get;set;}


        //InvoicePurchase
        public string? InvoicePurchaseID {get;set;}



    }
}
