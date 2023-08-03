using CardsLandingPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace CardsLandingPage.Controllers
{
    public class CredentialController : Controller
    {
        public IActionResult Authentication()
        {
            var data = new Credential { name = "test" , password="123456789"};
            return View();
        }
    }
}
