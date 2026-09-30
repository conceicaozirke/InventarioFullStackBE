namespace InventarioWebBE_FullStack.Models
{
    public class PriceTag
    {
        public int ID { get; set; }

        public required decimal Pricetag { get; set; }
        
        public DateTime PriceWhen { get; set; }

        public required decimal TotalCosts { get; set; }




        public required PriceBought PriceBought { get; set; }

        public required PriceMargin PriceMargin { get; set; }

       //publicar método para criar um pricetag usando Price bought- + dados buscados de invoice- *mult
       //do PriceMargin - price tag already done
       //public PriceTag() { 
        
        
        }





    }

