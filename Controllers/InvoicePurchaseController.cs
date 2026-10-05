using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Notas-fiscais-Compras")]



    public class InvoicePurchaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoicePurchaseController(AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _context.InvoicePurchase.ToListAsync();
            return Ok(invoices);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateInvoicePurchased([FromBody] InvoicePurchaseDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<InvoicePurchase>(_context, propa => propa.ID);
            var invoice = new InvoicePurchase
            {
                ID = newID,
                InvoiceNumber = dto.InvoicePurchaseNumber,
                Notes = dto.InvoicePurchaseNotes,
                PriceTotal= dto.InvoicePurchasePriceTotal,
                ShippingCost= dto.InvoicePurchaseShippingCost,
                TaxTotal= dto.InvoicePurchaseTaxTotal,
                PurchaseStatus= dto.InvoicePurchasePurchaseStatus,
                IsAvailable=dto.InvoicePurchaseIsAvailable,

                PurchaseDate = DateTime.UtcNow,

            };
            _context.InvoicePurchase.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok(invoice);
        }










    }
}





