namespace InventarioWebBE_FullStack.Models

{
    public class SoldProduct
    {
        public string ID { get; set; } = string.Empty;

        public required int QuantitySold { get; set; }
        public  decimal ShippingCost { get; set; }
        public required decimal Taxes { get; set; }
        public required decimal Profit { get; set; }
        public DateTime DateSold { get; set; } = DateTime.Now;

        public string ProductID { get; set; } =string.Empty;

        public string InvoiceSoldID { get; set; } = string.Empty;


        public  Product? Product { get; set; }

        public  InvoiceSold? InvoiceSold { get; set; }


       }
}
