using InventarioWebBE_FullStack.Models;

namespace InventarioWebBE_FullStack.DTO
{
    public class SoldProductRequest
    {
        public int ID { get; set; }

        public required int QuantitySold { get; set; }
        public int ShippingCost { get; set; }
        public required int Taxes { get; set; }
        public required int Profit { get; set; }
        public DateTime DateSold { get; set; } = DateTime.Now;


        //Product

        public string ProductID { get; set; } = string.Empty;

        public required string ProductName { get; set; }

        public int ProductQuantity { get; set; }

        public DateTime ProductLastUpdatedAt { get; set; } = DateTime.Now;




        //Brand
        public int BrandID { get; set; }

        public required string BrandName { get; set; }
        //PriceTag
        public int PriceTagID { get; set; }

        public decimal PriceTagPricetag { get; set; }

        //InvoicePurchase
        public string InvoicePurchaseID { get; set; } = string.Empty;

        public required int InvoiceNumber { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now;



        //InvoiceSold
        public int InvoiceSoldID { get; set; }

        public DateTime InvoiceSoldSellingDate { get; set; } = DateTime.Now;

        public bool SellingConfirmed { get; set; } = false;


    }
}
