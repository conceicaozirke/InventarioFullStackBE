using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Notas-Fiscais-Vendas")]



    public class SoldInvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoldInvoicesController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoice = await _context.InvoiceSold.ToListAsync();
            return Ok(invoice);

        }


        //PostBrand

        [HttpPost]



        public async Task<IActionResult> CreateInvoiceSold([FromBody] InvoiceSoldDTO dto)

        { 
            if (!ModelState.IsValid)
        {        return BadRequest(ModelState); }
          

            {
            string newID = await IDGen.StringIDGen<InvoiceSold>(_context, p => p.ID);


            var invoice = new InvoiceSold
            {
                SellingDate=DateTime.UtcNow,
                InvoiceNumber =dto.InvoiceInvoiceNumber,
                PriceTotal=dto.InvoiceSoldPriceTotal,
                TaxTotal=dto.InvoiceSoldTaxTotal,
                ShippingCost=dto.InvoiceSoldShippingCost,
                SellingStatus=dto.InvoiceSoldStatus,
                SellingConfirmed= dto.InvoiceSoldConfirmed,
            };

            _context.InvoiceSold.Add(invoice);
            await _context.SaveChangesAsync();

            return Ok(invoice);
        }


    }







    }
}





