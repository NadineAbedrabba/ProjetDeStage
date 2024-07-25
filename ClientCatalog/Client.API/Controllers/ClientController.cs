using Client.API.Data;
using Client.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase

{

    // GET: api/client
    [HttpGet]
    public IActionResult GetClients()
    {
        return Ok(ClientContext.clients);
    }

    // GET: api/client/{id}
    [HttpGet("{id}")]
    public IActionResult GetClient(int id)
    {
        var client = ClientContext.clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }
    [HttpPost]

    public ActionResult<ClientClass> CreateClient(ClientClass client)
    {
        if (client == null)
        {
            return BadRequest();
        }

        // Generate a new ID for the client
        client.Id = ClientContext.clients.Max(c => c.Id) + 1;
        client.RegistrationDate = DateTime.Now; // Set registration date to now
        ClientContext.clients.Add(client);
        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }
    [HttpPatch("{id}")]
    public IActionResult PatchClient(int id, [FromBody] JsonPatchDocument<ClientClass> patchDoc)
    {
        if (patchDoc == null)
        {
            return BadRequest();
        }

        var client = ClientContext.clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        patchDoc.ApplyTo(client, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(client);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        var client = ClientContext.clients.FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            return NotFound();
        }

        ClientContext.clients.Remove(client);
        return NoContent();
    }

}