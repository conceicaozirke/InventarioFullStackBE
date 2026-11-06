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
    [Route("api/Notas-Fiscais-Vendas")]



    public class SoldInvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoldInvoicesController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.InvoiceSold
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.SellingDate)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }

        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceSold([FromBody] InvoiceSoldDTO dto)

        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }


            {
                string newID = await IDGen.StringIDGen<InvoiceSold>(_context, p => p.ID);


                var invoice = new InvoiceSold
                {
                    SellingDate = DateTime.UtcNow,
                    InvoiceNumber = dto.InvoiceInvoiceNumber,
                    PriceTotal = dto.InvoiceSoldPriceTotal,
                    TaxTotal = dto.InvoiceSoldTaxTotal,
                    ShippingCost = dto.InvoiceSoldShippingCost,
                    SellingStatus = dto.InvoiceSoldStatus,
                    SellingConfirmed = dto.InvoiceSoldConfirmed,
                    IsDeleted = false,
                };

                _context.InvoiceSold.Add(invoice);
                await _context.SaveChangesAsync();

                return Ok(invoice);
            }
        }


                [HttpPut]

                public IActionResult Edit([FromBody] InvoiceSold nota)
                {
                    // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
                    if (nota == null
                        || string.IsNullOrEmpty(nota.ID)
                        || string.IsNullOrEmpty(nota.InvoiceNumber)
                        || nota.TaxTotal < 0
                        || nota.PriceTotal < 0
                        || nota.ShippingCost < 0)
                    {
                        return BadRequest("Dados inválidos.");
                    }

                    // 2. Attach the entity to EF Core without a GET roundtrip
                    _context.InvoiceSold.Attach(nota);

                    // 3. Flag only the properties you want to update in the DB
                    _context.Entry(nota).Property(x => x.InvoiceNumber).IsModified = true;
                    _context.Entry(nota).Property(x => x.ShippingCost).IsModified = true;
                    _context.Entry(nota).Property(x => x.TaxTotal).IsModified = true;
                    _context.Entry(nota).Property(x => x.PriceTotal).IsModified = true;
                    _context.Entry(nota).Property(x => x.ShippingCost).IsModified = true;
                    _context.Entry(nota).Property(x => x.SellingStatus).IsModified = true;
                    _context.Entry(nota).Property(x => x.SellingConfirmed).IsModified = true;

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

            var nota = await _context.InvoiceSold.FindAsync(id);
            if (nota == null)
            {
                return NotFound("Nota fiscal não encontrada!");
            }

            nota.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Nota fiscal deletada com sucesso!" });
        }




    }

} 







          






