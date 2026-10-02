namespace InventarioWebBE_FullStack.Models
{
    public class PriceTag
    {
        public int ID { get; set; }

        public required decimal Pricetag { get; set; }
        
        public DateTime PriceWhen { get; set; }

        public required decimal TotalCosts { get; set; }

        public required decimal Profit { get; set; }

        public int PriceBoughtID { get; set; }
        public int PriceMarginID { get; set; }



        public  PriceBought? PriceBought { get; set; }

        public  PriceMargin? PriceMargin { get; set; }

       
        
        
        }





    }

