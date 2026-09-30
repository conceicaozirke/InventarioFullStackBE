namespace InventarioWebBE_FullStack.Models

{
    public class SoldProduct
    {
        public int ID { get; set; }

        public required int QuantitySold { get; set; }
        public  decimal ShippingCost { get; set; }
        public required decimal Taxes { get; set; }
        public required decimal Profit { get; set; }
        public DateTime DateSold { get; set; } = DateTime.Now;



        public required Product Product { get; set; }

        public required InvoiceSold InvoiceSold { get; set; }


       }
}
