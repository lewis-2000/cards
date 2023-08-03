using CardsLandingPage.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CardsLandingPage.Services
{
    public class CardDBService
    {
        private readonly IMongoCollection<Card> _cardCollection;

        public CardDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase("CardDB");

            _cardCollection = database.GetCollection<Card>("card");

        }

        public async Task CreateCard(Card card)
        {
            await _cardCollection.InsertOneAsync(card);
            return;
        }

        public async Task<List<Card>> GetCard()
        {
            return await _cardCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToCard(string id, string CardId)
        {
            FilterDefinition<Card> filter = Builders<Card>.Filter.Eq("Id", id);
            UpdateDefinition<Card> update = Builders<Card>.Update.AddToSet<string>("items", CardId);
            await _cardCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteCard(string id)
        {
            FilterDefinition<Card> filter = Builders<Card>.Filter.Eq("Id", id);
            await _cardCollection.DeleteOneAsync(filter);
            return;
        }
    }
}

