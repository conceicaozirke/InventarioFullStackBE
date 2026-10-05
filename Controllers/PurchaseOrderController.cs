using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Ordem-de-compras")]



    public class PurchaseOrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PurchaseOrderController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _context.PurchaseOrder.ToListAsync();
            return Ok(order);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] PurchaseOrderDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<PurchaseOrder>(_context, propa => propa.ID);
            var order = new PurchaseOrder
            {
                OrderNumber = dto.PurchaseOrderOrderNumber,
                TotalPrice = dto.PurchaseOrderTotalPrice,
                ShippingCost = dto.PurchaseOrderShippingCost,
                Taxes = dto.PurchaseOrderTaxes,
                Profit = dto.PurchaseOrderProfit,
                InvoicePurchaseID = dto.InvoiceID,
                CreatedAt = DateTime.UtcNow,

            };


            _context.PurchaseOrder.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);











        }
    }
}






