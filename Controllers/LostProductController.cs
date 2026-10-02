using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
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
        public async Task<IActionResult> GetAll()
        {
            var lostproduct = await _context.LostProduct.ToListAsync();
            return Ok(lostproduct);

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
            };



            
            _context.LostProduct.Add(lostproduct);
            await _context.SaveChangesAsync();

            return Ok(lostproduct);
        }










    }
}





