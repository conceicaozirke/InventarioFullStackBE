namespace InventarioWebBE_FullStack.Models
{
    public class PriceBought
    {
     public int ID { get; set; }
     
     public decimal UnitPrice { get; set; }
     public decimal ShippingCost { get; set; }
     public decimal Taxes { get; set; }

             
     public required InvoicePurchase InvoicePurchase { get; set; }

    }
}
