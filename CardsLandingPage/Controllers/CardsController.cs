using cards.Models;
using CardsApi;
using CardsLandingPage.DataConnection;
using CardsLandingPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CardsLandingPage. ControllerBase
{
    [Route("[Controller]")]
    [ApiController]
    public class CardsController : Controller
    {

        public IActionResult Get()
        {
            /*  var info = new List<Credential> { 
                  new Credential{ name="Lewis nganga", password="123456789secure"},
                  new Credential{ name="Prince mungai", password="123456789maybesecure"}

              };
            */
            var info = new Credential { name = "Lewis nganga", password = "123456789secure" };
            return Ok(info) ;

        }
    }
}
