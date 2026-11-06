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
    [Route("api/Precos-de-compras")]



    public class ProiceBoughtController: ControllerBase
    {
        private readonly AppDbContext _context;

        public ProiceBoughtController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.PriceBought
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.BoughtWhen)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

          return Ok(pagedResult);
        }

        //PostBrand

        [HttpPost]
        public async Task<IActionResult> NewPriceBought([FromBody] PriceBoughtDTO dto)
        {
            var price = new PriceBought
            {
                UnitPrice = dto.PriceBoughtUnityPrice,
                ShippingCost= dto.PriceBoughtShippingCost,
                Taxes = dto.PriceBoughtTaxes,
                InvoicePurchaseID= dto.InvoicePurchaseID,
                BoughtWhen = DateTime.UtcNow,
                IsDeleted = false,
            };

            _context.PriceBought.Add(price);
            await _context.SaveChangesAsync();

            return Ok(price);
        }


        [HttpPut]
        public IActionResult Edit([FromBody] PriceBought price)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (price == null
                || string.IsNullOrEmpty(price.InvoicePurchaseID)
                || price.UnitPrice < 0
                || price.Taxes < 0
                || price.ShippingCost < 0)
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.PriceBought.Attach(price);

            // 3. Flag only the properties you want to update in the DB
            _context.Entry(price).Property(x => x.UnitPrice).IsModified = true;
            _context.Entry(price).Property(x => x.Taxes).IsModified = true;
            _context.Entry(price).Property(x => x.ShippingCost).IsModified = true;
            _context.Entry(price).Property(x => x.InvoicePurchaseID).IsModified = true;

            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(price);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID inválido.");
            }

            var produto = await _context.PriceBought.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            produto.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Produto deletado com sucesso!" });
        }



    }








    }






