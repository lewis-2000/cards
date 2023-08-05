using cards.Services;
using cards.Models;
using Microsoft.AspNetCore.Mvc;

namespace cards.Controllers
{
    [Route("api/CardDB")]
    [ApiController]
    public class CardDBController : Controller
    {
        //Dependency Injection
        private readonly CardDBService _cardDBService;

        public CardDBController(CardDBService cardDBService) 
        {
            _cardDBService = cardDBService;
        }

        /// <summary>
        /// Return all CardDB Items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<CardDB>> GetCards() 
        {
            return await _cardDBService.GetCardDB();
        }
        /// <summary>
        /// Creates a card to the CardDB with a unique id
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CardDB card)
        {
            await _cardDBService.CreateCard(card);
            return CreatedAtAction(nameof(AddCard), new { id = card.Id }, card);
        }

        /// <summary>
        /// Deletes a card to the cardDB using a specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(string id)
        {
            await _cardDBService.DeleteCardDB(id);
            return NoContent();
        }

        /// <summary>
        /// Appends items to a card using a specific id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> AddToCards(string id, [FromBody] string cardId)
        {
            await _cardDBService.AddToCardDB(id, cardId);
            return NoContent();
        }


    }
}
