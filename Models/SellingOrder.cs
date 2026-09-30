namespace InventarioWebBE_FullStack.Models
{
    public class SellingOrder
    {
        public int ID { get; set; }

        public required int OrderNumber {  get; set; } 

        public required decimal TotalPrice { get; set; }

        public required decimal ShippingCost { get; set; }

        public required decimal Taxes { get; set; }

        public required decimal Profit { get; set; }


        public required InvoiceSold InvoiceSold { get; set; }

    }
}
