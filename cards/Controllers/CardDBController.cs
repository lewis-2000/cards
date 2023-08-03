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

        [HttpGet]
        public async Task<List<CardDB>> GetCards() 
        {
            return await _cardDBService.GetCardDB();
        }

        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] CardDB card)
        {
            await _cardDBService.CreateCard(card);
            return CreatedAtAction(nameof(AddCard), new { id = card.Id }, card);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(string id)
        {
            await _cardDBService.DeleteCardDB(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddToCards(string id, [FromBody] string cardId)
        {
            await _cardDBService.AddToCardDB(id, cardId);
            return NoContent();
        }


    }
}
