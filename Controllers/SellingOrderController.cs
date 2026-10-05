using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Ordem-de-vendas")]



    public class SellingOrderController: ControllerBase
    {
        private readonly AppDbContext _context;

        public SellingOrderController(AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _context.SellingOrder.ToListAsync();
            return Ok(order);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateSellingOrder([FromBody] SellingOrderDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<SellingOrder>(_context, propa => propa.ID);
            var order = new SellingOrder
            {
                OrderNumber=dto.SellingOrderOrderNumber,
                TotalPrice=dto.SellingOrderTotalPrice,
                ShippingCost=dto.SellingOrderShippingCost,
                Taxes=dto.SellingOrderTaxes,
                Profit=dto.SellingOrderProfit,
                CreatedAt=DateTime.UtcNow,
                InvoicedID = dto.InvoiceID,
            };

            _context.SellingOrder.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }










    }
}





