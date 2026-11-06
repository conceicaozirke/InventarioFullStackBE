using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Helpers;
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
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.InvoicePurchase
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.PurchaseDate)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
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
                IsDeleted=false,

                PurchaseDate = DateTime.UtcNow,

            };
            _context.InvoicePurchase.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok(invoice);
        }


        [HttpPut]
        public IActionResult Edit([FromBody] InvoicePurchase nota)
        {
            if (nota == null
                || string.IsNullOrEmpty(nota.ID)
                || string.IsNullOrEmpty(nota.InvoiceNumber)
                || nota.PriceTotal < 0
                || nota.TaxTotal < 0
                || nota.ShippingCost < 0)
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.InvoicePurchase.Attach(nota);

            // 3. Flag only the properties you want to update in the DB
            _context.Entry(nota).Property(x => x.InvoiceNumber).IsModified = true;
            _context.Entry(nota).Property(x => x.PriceTotal).IsModified = true;
            _context.Entry(nota).Property(x => x.TaxTotal).IsModified = true;
            _context.Entry(nota).Property(x => x.ShippingCost).IsModified = true;
            _context.Entry(nota).Property(x => x.Notes).IsModified = true;
            _context.Entry(nota).Property(x => x.IsAvailable).IsModified = true;
            _context.Entry(nota).Property(x => x.PurchaseStatus).IsModified = true;

            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(nota);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID inválido.");
            }

            var nota = await _context.InvoicePurchase.FindAsync(id);
            if (nota == null)
            {
                return NotFound("Nota fisca não encontrada!");
            }

            nota.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Nota fiscal deletada com sucesso!" });
        }





    }
}





