using CardsLandingPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CardsLandingPage.Pages
{
    public class DashboardModel : PageModel
    {
        public List<Shoes> shoes = new List<Shoes>
        {
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"}, 
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"}, 
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"},
            new Shoes{name="jordans", makeModel="sports", price=300, previousPrice=200, shopName="Marias Shop"} 
        
        };

        public void OnGet()
        {
        }
    }
}
