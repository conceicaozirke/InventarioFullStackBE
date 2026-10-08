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
    [Route("api/Produtos")]



    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context) { _context = context; }



        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.Product
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.LastUpdatedAt)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> StringIDGen([FromBody] ProductDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<Product>(_context, p => p.ID);

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
                    IsDeleted = false,
                };
                _context.Product.Add(prod);
                await _context.SaveChangesAsync();

                return Ok(prod);
            }
        }



            [HttpPut]
            public IActionResult Edit([FromBody] Product prod)
            {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (prod == null || string.IsNullOrEmpty(prod.ID)
                || prod.PriceTagID <= 0
                || prod.PriceBoughtID <= 0
                || string.IsNullOrEmpty(prod.InvoicePurchaseID)
                || prod.Quantity <= 0
                ||prod.BrandID <= 0
                || string.IsNullOrEmpty(prod.ProductName)
                    )
                {
                    return BadRequest("Dados inválidos.");
                }

                // 2. Attach the entity to EF Core without a GET roundtrip
                _context.Product.Attach(prod);

            // 3. Flag only the properties you want to update in the DB

                prod.LastUpdatedAt = DateTime.UtcNow;
                _context.Entry(prod).Property(x => x.ProductName).IsModified = true;
                _context.Entry(prod).Property(x => x.Quantity).IsModified = true;
                _context.Entry(prod).Property(x => x.Notes).IsModified = true;
                _context.Entry(prod).Property(x => x.PriceBoughtID).IsModified = true;
                _context.Entry(prod).Property(x => x.BrandID).IsModified = true;
                _context.Entry(prod).Property(x => x.PriceTagID).IsModified = true;
                _context.Entry(prod).Property(x => x.InvoicePurchaseID).IsModified = true;
                _context.Entry(prod).Property(x => x.PriceBoughtID).IsModified = true;



                // 4. Execute the SQL UPDATE
                _context.SaveChanges();

                return Ok(prod);
            }



            [HttpDelete("{id}")]
            public async Task<IActionResult> SoftDelete(string id)
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("ID inválido.");
                }

                var prod = await _context.Product.FindAsync(id);
                if (prod == null)
                {
                    return NotFound("Produto não encontrado.");
                }

                prod.IsDeleted = true;
                await _context.SaveChangesAsync();

                return Ok(new { message = "Produto deletado com sucesso!" });
            }









        }
    }






