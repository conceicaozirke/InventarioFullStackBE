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
    [Route("api/Etiqueta-de-preco")]



    public class PriceTagController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PriceTagController (AppDbContext context) { _context = context; }



       
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.PriceTag
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.PriceWhen)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreatePriceTag([FromBody] PriceTagDTO dto)
        {
            var tag = new PriceTag
            {
                Pricetag=dto.Pricetag_Pricetag,

                PriceWhen= DateTime.UtcNow,
                
                TotalCosts= dto.PricetagTotalCosts,

                Profit=dto.PriceTagProfit,

                PriceBoughtID=dto.PriceBoughtID,

                PriceMarginID=dto.MarginID,
                IsDeleted = false,
            };
            _context.PriceTag.Add(tag);
            await _context.SaveChangesAsync();

            return Ok(tag);
        }


        [HttpPut]
        public IActionResult Edit([FromBody] PriceTag tag)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (tag == null || tag.ID < 1
                || tag.Pricetag <= 0
                || tag.PriceBoughtID <= 0
                || tag.PriceMarginID <= 0
                )
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.PriceTag.Attach(tag);

            // 3. Flag only the properties you want to update in the DB
           
                  tag.PriceWhen = DateTime.UtcNow;
                _context.Entry(tag).Property(x => x.TotalCosts).IsModified=true;
                _context.Entry(tag).Property(x => x.TotalCosts).IsModified=true;
                _context.Entry(tag).Property(x => x.PriceMarginID).IsModified=true;
                _context.Entry(tag).Property(x => x.PriceBoughtID).IsModified=true;
            


            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(tag);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID inválido.");
            }

            var tag = await _context.PriceTag.FindAsync(id);
            if (tag == null)
            {
                return NotFound("Etiqueta de preço não encontrada.");
            }

            tag.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Etiqueta de preço deletada com sucesso!" });
        }








    }
}





