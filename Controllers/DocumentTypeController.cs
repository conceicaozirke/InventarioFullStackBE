using InventarioWebBE_FullStack.Data;
using InventarioWebBE_FullStack.DTO;
using InventarioWebBE_FullStack.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventarioWebBE_FullStack.Controllers
{

    [ApiController]
    [Route("api/Novo-tipo-de-Documento")]



    public class DocumentTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocumentTypeController(AppDbContext context) { _context = context; }

      
        
        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctype = await _context.DocumentType.ToListAsync();
            return Ok(doctype);

        }


        //PostBrand

        [HttpPost]
        public async Task<IActionResult> CreateDocType([FromBody] DocTypeDTO dto)
        {
            var doctype = new DocumentType
            {
                Name = dto.DocumentTypeName,
                Notes = dto.DocumentTypeNotes,
                



            };
            _context.DocumentType.Add(doctype);
            await _context.SaveChangesAsync();

            return Ok(doctype);
        }










    }
}





