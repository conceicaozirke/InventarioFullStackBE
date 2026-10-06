using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Etiqueta-de-preco")]



    public class PriceTagController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PriceTagController (AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tag = await _context.PriceTag.ToListAsync();
            return Ok(tag);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreatePriceTag([FromBody] PriceTagDTO dto)
        {
            var tag = new PriceTag
            {
                Pricetag=dto.Pricetag_Pricetag,

                PriceWhen= DateTime.UtcNow,
                
                TotalCosts= dto.PricetagTotalCosts,

                Profit=dto.PriceTagProfit,

                PriceBoughtID=dto.PriceBoughtID,

                PriceMarginID=dto.MarginID,
                IsDeleted = false,
            };
            _context.PriceTag.Add(tag);
            await _context.SaveChangesAsync();

            return Ok(tag);
        }










    }
}





