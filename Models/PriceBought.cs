namespace InventarioWebBE_FullStack.Models
{
    public class PriceBought
    {
     public int ID { get; set; }
     
     public decimal UnitPrice { get; set; }
     public decimal ShippingCost { get; set; }
     public decimal Taxes { get; set; }

    public string? InvoicePurchaseID { get; set; }

     public DateTime BoughtWhen { get; set; }=DateTime.Now;

    public bool IsDeleted { get; set; } = false;

        public  InvoicePurchase? InvoicePurchase { get; set; }

    }
}
