using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioWebBE_FullStack.Data; 

namespace InventarioWebBE_FullStack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context; 

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("check-connection")]
        public async Task<IActionResult> CheckConnection()
        {
            try
            {
                // Force raw connection open to bypass CanConnectAsync exception swallowing
                await _context.Database.OpenConnectionAsync();
                await _context.Database.CloseConnectionAsync();

                return Ok(" Connection Successful! DB and BE are 100% connected! ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"MySQL Rejection Detail: {ex.Message}");
            }
        }
    }
}
