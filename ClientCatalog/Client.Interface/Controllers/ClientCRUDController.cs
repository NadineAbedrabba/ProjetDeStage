using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Interface.Models;
using Microsoft.AspNetCore.JsonPatch;

[Route("ClientCRUD")]
public class ClientCRUDController : Controller
{
    private readonly HttpClient _httpClient;

    public ClientCRUDController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ClientAPIClient");
    }

    [HttpGet("Search")]
    public IActionResult Search()
    {
        return View();
    }


    [HttpGet("SearchClient")]
    public async Task<IActionResult> SearchClient([FromQuery] int searchQuery)
    {
        var response = await _httpClient.GetAsync($"/api/client/{searchQuery}");
        if (!response.IsSuccessStatusCode)
        {
            return NotFound(); // Retourner une réponse 404 si le client n'est pas trouvé
        }

        var content = await response.Content.ReadAsStringAsync();
        var client = JsonConvert.DeserializeObject<ClientClass>(content);
        return Json(client); // Retourner le client en format JSON
    }
    [HttpGet("Create")]
    public IActionResult Create()
    {
        return View();
    }

   

    [HttpPost("Create")]
    public async Task<IActionResult> Create(ClientClass client)
    {
        if (ModelState.IsValid)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/client", client);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while creating the client.");
            }
        }
        return View(client);
    } 

    [HttpGet("Delete")]
    public IActionResult Delete()
    {
        return View();
    }

    [HttpDelete("DeleteClient")]
    /*public async Task<IActionResult> DeleteClient(int ClientId)
    {
        var response = await _httpClient.DeleteAsync($"/api/client/${ClientId}");
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index","Home");    [FromQuery] int searchQuery
        }
        else
        {
            ModelState.AddModelError("", "An error occurred while deleting the client.");
            return View();
        }
    }*/
    public async Task<IActionResult> DeleteClient([FromQuery] int deleteQuery)
   {
       var response = await _httpClient.DeleteAsync($"/api/client/{deleteQuery}");
       if (response.IsSuccessStatusCode)
       {
           return RedirectToAction("Index","Home");   
       }
       else
       {
           ModelState.AddModelError("", "An error occurred while deleting the client. ");
           return View();
       }
   }

    [HttpGet("Update")]
    public IActionResult Update()
    {
        return View();
    }

    [HttpPost("Update/{id}")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] JsonPatchDocument<ClientClass> patchDoc)
    {
        var response = await _httpClient.PatchAsync($"/api/client/{id}", JsonContent.Create(patchDoc));
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }
}
