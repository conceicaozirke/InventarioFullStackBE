namespace InventarioWebBE_FullStack.Models

{
    public class BougthProduct
    {
        public string ID { get; set; } = string.Empty;

        public required int Quantity { get; set; }
        public  decimal ShippingCost { get; set; }
        public required decimal Taxes { get; set; }
        public DateTime DateBought { get; set; } = DateTime.Now;

        public string ProductID { get; set; } =string.Empty;

        public string InvoicePurchaseID { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public  Product? Product { get; set; }

        public  InvoicePurchase? InvoicePurchase { get; set; }


       }
}
