using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Produtos")]



    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prod = await _context.Product.ToListAsync();
            return Ok(prod);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> StringIDGen([FromBody] ProductDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<Product>(_context, propa => propa.ID);

            {
                var prod = new Product
                {
                    ID = newID,
                    ProductName = dto.Product_ProductName,
                    Quantity = dto.ProductQuantity,
                    Notes = dto.ProductNotes,
                    CreatedAt = DateTime.UtcNow,
                    LastUpdatedAt = DateTime.UtcNow,
                    BrandID = dto.BrandID,
                    PriceTagID = dto.PricetagID,
                    InvoicePurchaseID = dto.InvoicePurchaseID,
                    PriceBoughtID = dto.PriceboughtID,
                };
                _context.Product.Add(prod);
                await _context.SaveChangesAsync();

                return Ok(prod);
            }










        }
    }
}





