using cards.Models;
using cards.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreDBController : ControllerBase
    {
        //Dependency Injection
        private readonly StoreDBService _storeDBService;

        public StoreDBController(StoreDBService storeDBService)
        {
            _storeDBService = storeDBService;
        }

        /// <summary>
        /// Gets a storeDB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<StoreDB>> GetStoreDB()
        {
            return await _storeDBService.GetStoreDB();
        }

        /// <summary>
        /// Creates a storeDB with a unique key
        /// </summary>
        /// <param name="storeDB"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStoreDB([FromBody] StoreDB storeDB)
        {
            await _storeDBService.CreateStoreDB(storeDB);
            return CreatedAtAction(nameof(GetStoreDB), new { id = storeDB.ProductId }, storeDB);
        }

        /// <summary>
        /// Deletes a storeDB using a unique key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreDB(string id)
        {
            await _storeDBService.DeleteStoreDB(id);
            return NoContent();
        }

        /// <summary>
        /// Appends to storeDB using a unique key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="storeDBId"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToStoreDB(string id, [FromBody] string storeDBId)
        {
            await _storeDBService.AddToStoreDB(id, storeDBId);
            return NoContent();
        }

    }
}
