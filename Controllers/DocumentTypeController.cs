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
    [Route("api/Novo-tipo-de-Documento")]



    public class DocumentTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocumentTypeController(AppDbContext context) { _context = context; }



        //GetBrand
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParamsDTO dto)
        {
            var pagedResult = await _context.DocumentType
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToPagedListAsync(dto.PageNumber, dto.PageSize);

            return Ok(pagedResult);
        }


        //PostBrand

      
        [HttpPost]
        public async Task<IActionResult> CreateDocType([FromBody] DocTypeDTO dto)
        {
            var doctype = new DocumentType
            {
                Name = dto.DocumentTypeName,
                Notes = dto.DocumentTypeNotes,
                CreatedAt=DateTime.UtcNow,
                IsDeleted = false,
                



            };
            _context.DocumentType.Add(doctype);
            await _context.SaveChangesAsync();

            return Ok(doctype);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] DocumentType doctype)
        {
            // Validação- se nulo, string vaziam Quantidade menor que 1, Taxa menor que zero, 
            if (doctype == null)
            {
                return BadRequest("Dados inválidos.");
            }

            // 2. Attach the entity to EF Core without a GET roundtrip
            _context.DocumentType.Attach(doctype);

            // 3. Flag only the properties you want to update in the DB
            _context.Entry(doctype).Property(x => x.Name).IsModified = true;
            _context.Entry(doctype).Property(x => x.Notes).IsModified = true;
            
            // 4. Execute the SQL UPDATE
            _context.SaveChanges();

            return Ok(doctype);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID inválido.");
            }

            var produto = await _context.DocumentType.FindAsync(id);
            if (produto == null)
            {
                return NotFound("Tipo de documento não encontrado.");
            }

            produto.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tipo de documento deletado com sucesso!" });
        }









    }
}





