using cards.Services;
using cards.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCreditDBController : ControllerBase
    {
        //Dependency Injection
        private readonly PurchaseCreditDBService _purchaceCreditDBService;

        public PurchaseCreditDBController(PurchaseCreditDBService purchaceCreditDBService)
        {
            _purchaceCreditDBService = purchaceCreditDBService;
        }

        /// <summary>
        /// Gets all Purchase creditDB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PurchaseCreditDB>> GetPurchaseCredit()
        {
            return await _purchaceCreditDBService.GetPurchceCreditDB();
        }

        /// <summary>
        /// Creates a purchaseCreditDB with a unique key
        /// </summary>
        /// <param name="purchaseCredit"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPurchaseCredit([FromBody] PurchaseCreditDB purchaseCredit)
        {
            await _purchaceCreditDBService.CreatePurchceCreditDB(purchaseCredit);
            return CreatedAtAction(nameof(AddPurchaseCredit), new { id = purchaseCredit.Id }, purchaseCredit);
        }

        /// <summary>
        /// Deletes a purchaseCreditDB using a unique key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseCredit(string id)
        {
            await _purchaceCreditDBService.DeletePurchceCreditDB(id);
            return NoContent();
        }

        /// <summary>
        /// Appends to a purchase creditDB using a unique key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToPurchaseCredit(string id, [FromBody] string purchaseId)
        {
            await _purchaceCreditDBService.AddToPurchceCreditDB(id, purchaseId);
            return NoContent();
        }

    }
}
