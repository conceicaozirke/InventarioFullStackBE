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
    [Route("api/Produtos-Extraviados")]



    public class LostProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LostProductController (AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.LostProduct
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.LostDate)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }

        //Post extravio

        [HttpPost]
        public async Task<IActionResult> CreateLostProduct ([FromBody] LostProductDTO dto)
        {
            var lostproduct = new LostProduct
            {

                LostDate = DateTime.UtcNow,
                Quantity = dto.LostProductQuantity,
                Notes = dto.LostNotes,
                ProductID = dto.ProductID,
                IsDeleted = false,
            };                                 
            _context.LostProduct.Add(lostproduct);
            await _context.SaveChangesAsync();

            return Ok(lostproduct);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] LostProduct produto)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (produto.ID <1
                || string.IsNullOrEmpty(produto.Notes)
                || produto.Quantity < 1)
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.LostProduct.Attach(produto);

            // 3. Flag only the properties you want to update in the DB
            _context.Entry(produto).Property(x => x.LostDate).IsModified = true;
            _context.Entry(produto).Property(x => x.Quantity).IsModified = true;
            _context.Entry(produto).Property(x => x.Notes).IsModified = true;
            _context.Entry(produto).Property(x => x.ProductID).IsModified = true;
           // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID inválido.");
            }

            var produto = await _context.LostProduct.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Perda de produtos não encontrada.");
            }

            produto.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Perda de produtos deletada com sucesso!" });
        }






    }
}





