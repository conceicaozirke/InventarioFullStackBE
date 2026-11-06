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
    [Route("api/Venda-de-Produto")]



    public class SoldProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoldProductController(AppDbContext context) { _context = context; }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.SoldProduct
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.DateSold)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> AddSoldProduct([FromBody] SoldProductDTO dto)
            {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<SoldProduct>(_context, propa => propa.ID);



            var selling = new SoldProduct
            {
                ID = newID,
                QuantitySold=dto.QuantitySold,
                ShippingCost=dto.ShippingCost,
                Taxes=dto.Taxes,
                Profit=dto.Profit,
                ProductID=dto.ProductID,
                InvoiceSoldID=dto.InvoiceSoldID,
                DateSold=DateTime.UtcNow,
                IsDeleted = false,
            };
            _context.SoldProduct.Add(selling);
            await _context.SaveChangesAsync();

            return Ok(selling);
        }




        [HttpPut]
        public IActionResult Edit([FromBody] SoldProduct prod)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (prod == null || string.IsNullOrEmpty(prod.ID)
                || prod.Taxes < 0
                || prod.ShippingCost < 0
                || prod.Profit < 0
                || prod.QuantitySold < 0
                || string.IsNullOrEmpty(prod.InvoiceSoldID))
                

            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.SoldProduct.Attach(prod);

            // 3. Flag only the properties you want to update in the DB  

            prod.DateSold = DateTime.UtcNow;
            _context.Entry(prod).Property(x => x.ShippingCost).IsModified = true;
            _context.Entry(prod).Property(x => x.Taxes).IsModified = true;
            _context.Entry(prod).Property(x => x.Profit).IsModified = true;
            _context.Entry(prod).Property(x => x.InvoiceSoldID).IsModified = true;
            _context.Entry(prod).Property(x => x.ProductID).IsModified = true;




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

            var prod = await _context.SoldProduct.FindAsync(id);
            if (prod == null)
            {
                return NotFound("Venda não encontrada.");
            }

            prod.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Venda deletada com sucesso!" });
        }








    }
}





