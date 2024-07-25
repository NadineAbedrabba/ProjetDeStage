using Microsoft.AspNetCore.Mvc;
using Client.Interface.Models;

namespace Client.Interface.Controllers
{
    public class ClientCRUDController : Controller
    {
        // GET: ClientCRUD/Search
        public IActionResult Search()
        {
            // Logique pour afficher les clients ou les résultats de recherche
            return View();
        }

        // GET: ClientCRUD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientCRUD/Create
        [HttpPost]
        public IActionResult Create(ClientClass client)
        {
            // Logique pour créer un nouveau client
            return RedirectToAction("Search");
        }

        // GET: ClientCRUD/Update/{id}
        public IActionResult Update(int id)
        {
            // Logique pour afficher le client à mettre à jour
            return View();
        }

        // POST: ClientCRUD/Update
        [HttpPost]
        public IActionResult Update(ClientClass client)
        {
            // Logique pour mettre à jour un client
            return RedirectToAction("Search");
        }

        // GET: ClientCRUD/Delete/{id}
        public IActionResult Delete(int id)
        {
            // Logique pour afficher les détails du client à supprimer
            return View();
        }

        // POST: ClientCRUD/Delete
        [HttpPost]
        public IActionResult Delete(ClientClass client)
        {
            // Logique pour supprimer un client
            return RedirectToAction("Search");
        }
    }
}
