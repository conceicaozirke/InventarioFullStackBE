using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Venda-de-Produto")]



    public class SoldProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoldProductController(AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var selling = await _context.SoldProduct.ToListAsync();
            return Ok(selling);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> AddSoldProduct([FromBody] SoldProductDTO dto)
            {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<SoldProduct>(_context, propa => propa.ID);



            var selling = new SoldProduct
            {
                ID = newID,
                QuantitySold=dto.QuantitySold,
                ShippingCost=dto.ShippingCost,
                Taxes=dto.Taxes,
                Profit=dto.Profit,
                ProductID=dto.ProductID,
                InvoiceSoldID=dto.InvoiceSoldID,
                DateSold=DateTime.UtcNow,
    };
            _context.SoldProduct.Add(selling);
            await _context.SaveChangesAsync();

            return Ok(selling);
        }










    }
}





