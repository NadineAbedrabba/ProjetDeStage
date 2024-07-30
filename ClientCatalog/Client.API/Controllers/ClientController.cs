using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Client.API.Models;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ClientDbContext _context;

    public ClientController(ClientDbContext context)
    {
        _context = context;      
    }

    // GET: api/client
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        var clients = await _context.Clients.ToListAsync();
        return Ok(clients);
    }

    // GET: api/client/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    // POST: api/client
    [HttpPost]
    public async Task<IActionResult> CreateClient(ClientClass client)
    {
        if (client == null)
        {
            return BadRequest();
        }

        client.RegistrationDate = DateTime.Now; // Set registration date to now
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }


    // DELETE: api/client/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
