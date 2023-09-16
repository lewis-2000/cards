using cards.Models;
using cards.Services;
using Microsoft.AspNetCore.Mvc;

namespace cards.Controllers
{
    [ApiController]
    [Route("DiscoverDB")]
    public class DiscoverDBController : Controller
    {
        //Dependency Injection
        private readonly DiscoverDBService _discoverDBService;

        public DiscoverDBController(DiscoverDBService discoverDB)
        {
            _discoverDBService = discoverDB;
        }

        /// <summary>
        /// Gets all DiscoverDB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<DiscoverDB>> GetDiscoverDB()
        {
            return await _discoverDBService.GetDiscoverCardDB();
        }

        /// <summary>
        /// Creates a discoverDB with a unique id
        /// </summary>
        /// <param name="discoverDB"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDiscoverDB([FromBody] DiscoverDB discoverDB)
        {
            await _discoverDBService.CreateDiscoverDB(discoverDB);
            return CreatedAtAction(nameof(GetDiscoverDB), new { id = discoverDB.ProductId }, discoverDB);
        }

        /// <summary>
        /// Deletes a discoverDB using a unique id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscoverDB(string id)
        {
            await _discoverDBService.DeleteDiscoverDB(id);
            return NoContent();
        }

        /// <summary>
        /// Appends items to discoverDB using a specific id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToDiscoverDB(string id, [FromBody] string cardId)
        {
            await _discoverDBService.AddToDiscoverDB(id, cardId);
            return NoContent();
        }

    }
}
