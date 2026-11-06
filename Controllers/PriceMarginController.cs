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
    [Route("api/Marge-de-Vendas")]



    public class PriceMarginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PriceMarginController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.PriceMargin
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }

        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateMargin([FromBody] PriceMarginDTO dto)
        {
            var margin = new PriceMargin
            {
                ProductName = dto.PriceMarginProductName,
                Notes = dto.PriceMarginNotes,
                MarginProp = dto.PriceMarginProp,
                CreatedAt= DateTime.UtcNow,
                IsDeleted = false,
            };


            _context.PriceMargin.Add(margin);
            await _context.SaveChangesAsync();

            return Ok(margin);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] PriceMargin margin)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (margin == null
                || string.IsNullOrEmpty(margin.ProductName)
                
                || margin.MarginProp <= 0 )
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.PriceMargin.Attach(margin);

            // 3. Flag only the properties you want to update in the DB
            _context.Entry(margin).Property(x => x.ProductName).IsModified = true;
            _context.Entry(margin).Property(x => x.Notes).IsModified = true;
            _context.Entry(margin).Property(x => x.MarginProp).IsModified = true;
            

            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(margin);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID inválido.");
            }

            var margin = await _context.PriceMargin.FindAsync(id);
            if (margin == null)
            {
                return NotFound("Margem não encontrada.");
            }

            margin.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Margem deletada com sucesso!" });
        }







    }
}





