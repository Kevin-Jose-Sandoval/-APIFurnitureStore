using APIFurnitureStore.Context;
using APIFurnitureStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFurnitureStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly FurnitureStoreContext _context;

        public ClientController(FurnitureStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                return Ok(await _context.Clients.ToListAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
                if (client == null) return NotFound();

                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientModel newClient)
        {
            try
            {
                await _context.Clients.AddAsync(newClient);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetClientById), new { id = newClient.Id }, newClient);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
