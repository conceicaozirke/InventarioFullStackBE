using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Compra-de-produto")]



    public class BoughtProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoughtProductController (AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var buying = await _context.BougthProduct.ToListAsync();
            return Ok(buying);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> AddSoldProduct([FromBody] BoughtProductDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<BougthProduct>(_context, pa => pa.ID);

            var buying = new BougthProduct
            {
                ID=newID,
                Quantity=dto.Quantity,
                ShippingCost=dto.ShippingCost,
                Taxes=dto.Taxes,
                DateBought=DateTime.UtcNow,
                ProductID=dto.ProductID,
                InvoicePurchaseID=dto.InvoicePurchaseID,

    };
            _context.BougthProduct.Add(buying);
            await _context.SaveChangesAsync();

            return Ok(buying);
        }










    }
}





