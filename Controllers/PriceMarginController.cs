using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
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
        public async Task<IActionResult> GetAll()
        {
            var margin = await _context.PriceMargin.ToListAsync();
            return Ok(margin);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateMargin([FromBody] PriceMarginDTO dto)
        {
            var margin = new PriceMargin
            {
                ProductName = dto.PriceMarginProductName,
                Notes = dto.PriceMarginNotes,
                MarginProp = dto.PriceMarginProp
            };


            _context.PriceMargin.Add(margin);
            await _context.SaveChangesAsync();

            return Ok(margin);
        }










    }
}





