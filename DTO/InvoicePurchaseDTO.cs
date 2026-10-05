namespace InventarioWebBE_FullStack.DTO
{
    public class InvoicePurchaseDTO
    {

        public required string InvoicePurchaseNumber { get; set; } = string.Empty;

        public string? InvoicePurchaseNotes { get; set; } 

        public DateTime InvoicePurchaseDate { get; set; } = DateTime.Now;

        public decimal InvoicePurchasePriceTotal { get; set; }

        public decimal InvoicePurchaseTaxTotal { get; set; }

        public decimal InvoicePurchaseShippingCost { get; set; }


        public string InvoicePurchasePurchaseStatus { get; set; } = string.Empty;

        public bool InvoicePurchaseIsAvailable { get; set; } = false;


    }
}
