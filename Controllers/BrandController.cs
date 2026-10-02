using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
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
        public async Task<IActionResult> GetAll()
        {
            var brand = await _context.Brand.ToListAsync();
            return Ok(brand);

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



                CreatedAt = DateTime.UtcNow,
            };
            _context.Brand.Add(brand);
            await _context.SaveChangesAsync();

            return Ok(brand);
        }










    }
}





