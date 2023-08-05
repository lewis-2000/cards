using cards.Models;
using CardsApi;
using CardsLandingPage.DataConnection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CardsLandingPage.Controllers
{
    public class CardsController : Controller
    {      

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var client = new swaggerClient("https://localhost:7018/swagger/v1/swagger.json", httpClient);
            ViewData["Results"] = await client.CardDBAllAsync();
            Console.WriteLine(client.CardDBAllAsync());

            return View();
        }
    }
}
