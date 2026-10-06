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
    [Route("api/Marcas")]



    public class BrandControllers : ControllerBase
    {
        private readonly AppDbContext _context;

        public BrandControllers(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.Brand
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] AddBrandDTO dto)
        {
            var brand = new Brand
            {
                Name = dto.BrandName,
                Adress = dto.BrandAdress,
                Notes = dto.BrandNotes,
                DocumentNumber = dto.BrandDocumentNumber,
                DocumentTypeID = dto.BrandDocumentTypeID,
                IsDeleted=false,



                CreatedAt = DateTime.UtcNow,
            };
            _context.Brand.Add(brand);
            await _context.SaveChangesAsync();

            return Ok(brand);
        }




        [HttpPut]
        public IActionResult Edit([FromBody] Brand brand)
        {

            if (brand == null
                || string.IsNullOrEmpty(brand.DocumentNumber)
                || brand.DocumentTypeID < 1)
                
            {
                return BadRequest("Dados inválidos.");
            }

            _context.Brand.Attach(brand);

            _context.Entry(brand).Property(x => x.Name).IsModified = true;
            _context.Entry(brand).Property(x => x.Adress).IsModified = true;
            _context.Entry(brand).Property(x => x.Notes).IsModified = true;
            _context.Entry(brand).Property(x => x.CreatedAt).IsModified = true;
            _context.Entry(brand).Property(x => x.DocumentTypeID).IsModified = true;
            _context.Entry(brand).Property(x => x.DocumentNumber).IsModified = true;

            _context.SaveChanges();

            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            if (id<0)
            {
                return BadRequest("ID inválido.");
            }

            var produto = await _context.Brand.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Marca não encontrada.");
            }

            produto.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Marca deletada com sucesso!" });
        }








    }
}





