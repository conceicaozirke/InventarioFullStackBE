namespace InventarioWebBE_FullStack.DTO
{
    public class PriceMarginRequest
    {
        public int PriceMarginID { get; set; }

       public required string PriceMarginProductName { get; set; }
        

       public string? PriceMarginNotes { get; set; }

        public float PriceMarginProp { get; set; }



    }
}
