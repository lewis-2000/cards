using CardsLandingPage.DataConnection;
using CardsLandingPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardsLandingPage.Controllers
{
    public class CredentialController : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            
           // var data = new Credential { name = "test" , password="123456789"};
            return View();
        }
    }
}
