using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Helpers;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Compra-de-produto")]

    
    public class BoughtProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BoughtProductController(AppDbContext context) { _context = context; }



        //Get MAS TEM PAGINAÇÃO
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.BougthProduct
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.DateBought)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }

        //PostBrand

        [HttpPost]
        public async Task<IActionResult> AddSoldProduct([FromBody] BoughtProductDTO dto)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
            }

            string newID = await IDGen.StringIDGen<BougthProduct>(_context, pa => pa.ID);

            var buying = new BougthProduct
            {
                ID = newID,
                Quantity = dto.Quantity,
                ShippingCost = dto.ShippingCost,
                Taxes = dto.Taxes,
                DateBought = DateTime.UtcNow,
                ProductID = dto.ProductID,
                InvoicePurchaseID = dto.InvoicePurchaseID,
                IsDeleted = false,

            };
            _context.BougthProduct.Add(buying);
            await _context.SaveChangesAsync();

            return Ok(buying);
        }




        [HttpPut]
        public IActionResult Edit([FromBody] BougthProduct produto)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (produto == null
                || string.IsNullOrEmpty(produto.ID)
                || string.IsNullOrEmpty(produto.InvoicePurchaseID)
                || produto.Quantity < 1
                || produto.Taxes < 0
                || produto.ShippingCost < 0)
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.BougthProduct.Attach(produto);

            // 3. Flag only the properties you want to update in the DB
            _context.Entry(produto).Property(x => x.Quantity).IsModified = true;
            _context.Entry(produto).Property(x => x.ShippingCost).IsModified = true;
            _context.Entry(produto).Property(x => x.Taxes).IsModified = true;
            _context.Entry(produto).Property(x => x.DateBought).IsModified = true;
            _context.Entry(produto).Property(x => x.ProductID).IsModified = true;
            _context.Entry(produto).Property(x => x.InvoicePurchaseID).IsModified = true;

            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(produto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest( "ID inválido.");
            }

            var produto = await _context.BougthProduct.FindAsync(id);
            if (produto == null)
            {
                return NotFound ("Produto não encontrado.");
            }

            produto.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Produto deletado com sucesso!" });
        }
    }
}





    







