using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Helpers;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
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




        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.PurchaseOrder
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }



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
                IsDeleted = false,

            };


            _context.PurchaseOrder.Add(order);
            await _context.SaveChangesAsync();

            return Ok(order);











        }




        [HttpPut]
        public IActionResult Edit([FromBody] PurchaseOrder order)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (order == null || string.IsNullOrEmpty(order.ID)
                || order.Taxes < 0
                || order.ShippingCost< 0
                || string.IsNullOrEmpty(order.InvoicePurchaseID)
                || order.OrderNumber <= 0
                || order.TotalPrice<= 0)
                

            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.PurchaseOrder.Attach(order);

            // 3. Flag only the properties you want to update in the DB

            order.CreatedAt= DateTime.UtcNow;
            _context.Entry(order).Property(x => x.ShippingCost).IsModified = true;
            _context.Entry(order).Property(x => x.Taxes).IsModified = true;
            _context.Entry(order).Property(x => x.Profit).IsModified = true;
            _context.Entry(order).Property(x => x.InvoicePurchase).IsModified = true;
            _context.Entry(order).Property(x => x.TotalPrice).IsModified = true;
           



            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(order);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID inválido.");
            }

            var prod = await _context.PurchaseOrder.FindAsync(id);
            if (prod == null)
            {
                return NotFound("Ordem de compras não encontrada.");
            }

            prod.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Ordem de compras deletada com sucesso!" });
        }





    }
}






