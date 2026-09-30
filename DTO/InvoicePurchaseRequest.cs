namespace InventarioWebBE_FullStack.DTO
{
    public class InvoicePurchaseRequest
    {
        public string InvoicePurchaseID { get; set; } = string.Empty;

        public required int InvoicePurchaseNumber { get; set; }

        public string? InvoicePurchaseNotes { get; set; } 

        public DateTime InvoicePurchaseDate { get; set; } = DateTime.Now;

        public decimal InvoicePurchasePriceTotal { get; set; }

        public decimal InvoicePurchaseTaxTotal { get; set; }

        public decimal InvoicePurchaseShippingCost { get; set; }


        public string InvoicePurchasePurchaseStatus { get; set; } = string.Empty;

        public bool InvoicePurchaseIsAvailable { get; set; } = false;


    }
}
