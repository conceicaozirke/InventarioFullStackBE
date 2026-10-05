namespace InventarioWebBE_FullStack.Models
{
    public class InvoicePurchase
    {
        public string ID { get; set; } = string.Empty;

        public required string InvoiceNumber { get; set; } = string.Empty;

        public string? Notes { get; set; } 

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public decimal PriceTotal { get; set; }

        public decimal TaxTotal { get; set; }

        public decimal ShippingCost { get; set; }


        public string PurchaseStatus { get; set; } = string.Empty;

        public bool IsAvailable { get; set; } = false;

    }

     

    }

