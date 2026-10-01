using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioWebBE_FullStack.Data; // Replace with your actual DbContext namespace

namespace InventarioWebBE_FullStack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly AppDbContext _context; // Replace AppDbContext with your DbContext class name

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("check-connection")]
        public async Task<IActionResult> CheckConnection()
        {
            bool canConnect = await _context.Database.CanConnectAsync();

            if (canConnect)
                return Ok(" Connection Successful! DB and BE are 100% connected! ");

            return StatusCode(500, "Could not connect to MySQL container.");
        }
    }
}