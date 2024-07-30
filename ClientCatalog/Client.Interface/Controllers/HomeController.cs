using Client.Interface.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;


namespace Client.Interface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientfactory)
        
        {
            _logger = logger;
            _httpClient = httpClientfactory.CreateClient("ClientAPIClient");
         }

        public async Task<IActionResult> Index()
        {

            //var response = await _httpClient.GetAsync("/client");
            //var content = await response.Content.ReadAsStringAsync();
            //var clientList = JsonConvert.DeserializeObject<IEnumerable<ClientClass>>(content);

            // return View(clientList);

            //var clients =  ClientContext.clients;
            //return View(clients);
            try
            {
                var response = await _httpClient.GetAsync("/api/client");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var clientList = JsonConvert.DeserializeObject<IEnumerable<ClientClass>>(content);

                return View(clientList);
            }
            catch (HttpRequestException ex) { 
                Console.WriteLine($"Request error http makhdemsh: {ex.Message}");
            return StatusCode(500, "Internal server error");
            }
        }
   



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
