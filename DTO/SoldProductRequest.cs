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

      
        //Brand
        public int BrandID { get; set; }

        

        //InvoicePurchase
        public string InvoicePurchaseID { get; set; } = string.Empty;



        //InvoiceSold
        public int InvoiceSoldID { get; set; }

      


    }
}
