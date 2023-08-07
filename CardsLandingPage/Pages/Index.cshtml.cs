using CardsLandingPage.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardsLandingPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public List<Credential> info =  new List<Credential> 
        { 
                new Credential{ name="Lewis nganga", password="123456789secure"},
                new Credential{ name="Prince mungai", password="123456789maybesecure"}
            
           };


        public void OnGet()
                {

                }
    }
}