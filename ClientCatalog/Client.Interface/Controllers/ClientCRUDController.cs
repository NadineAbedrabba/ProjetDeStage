using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Client.Interface.Models;
using Microsoft.AspNetCore.JsonPatch;

public class ClientCRUDController : Controller
{
    private readonly HttpClient _httpClient;

    public ClientCRUDController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ClientAPIClient");
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ClientClass client)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/client", client);
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _httpClient.DeleteAsync($"/api/client/{id}");
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Update()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, [FromBody] JsonPatchDocument<ClientClass> patchDoc)
    {
        var response = await _httpClient.PatchAsync($"/api/client/{id}", JsonContent.Create(patchDoc));
        response.EnsureSuccessStatusCode();

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Search(string query)
    {
        var response = await _httpClient.GetAsync($"/api/client?search={query}");
        var content = await response.Content.ReadAsStringAsync();
        var clientList = JsonConvert.DeserializeObject<IEnumerable<ClientClass>>(content);

        return View(clientList);
    }
}
