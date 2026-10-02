using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Precos-de-compras")]



    public class ProiceBoughtController: ControllerBase
    {
        private readonly AppDbContext _context;

        public ProiceBoughtController(AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prices = await _context.PriceBought.ToListAsync();
            return Ok(prices);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> NewPriceBought([FromBody] PriceBoughtDTO dto)
        {
            var price = new PriceBought
            {
                UnitPrice = dto.PriceBoughtUnityPrice,
                ShippingCost= dto.PriceBoughtShippingCost,
                Taxes = dto.PriceBoughtTaxes,
                InvoicePurchaseID= dto.InvoicePurchaseID
                
                };

            _context.PriceBought.Add(price);
            await _context.SaveChangesAsync();

            return Ok(price);
        }










    }
}





