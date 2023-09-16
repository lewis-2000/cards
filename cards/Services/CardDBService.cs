using cards.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cards.Services
{
    public class CardDBService
    {
        private readonly IMongoCollection<CardDB> _cardCollection;

        public CardDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase("CardDB");

            _cardCollection = database.GetCollection<CardDB>("card");

        }

        //Create Card
        public async Task CreateCard(CardDB card)
        {
            await _cardCollection.InsertOneAsync(card);
            return;
        }

        //Get CardDB
        public async Task<List<CardDB>> GetCardDB()
        {
            return await _cardCollection.Find(new BsonDocument()).ToListAsync();
        }

        //Add to CardDB
        public async Task AddToCardDB(string id, string CardId)
        {
            FilterDefinition<CardDB> filter = Builders<CardDB>.Filter.Eq("Id", id);
            UpdateDefinition<CardDB> update = Builders<CardDB>.Update.AddToSet<string>("items", CardId);
            await _cardCollection.UpdateOneAsync(filter, update);
            return;
        }

        //Delete from CardDB
        public async Task DeleteCardDB(string id)
        {
            FilterDefinition<CardDB> filter = Builders<CardDB>.Filter.Eq("Id", id);
            await _cardCollection.DeleteOneAsync(filter);
            return;
        }
    }
}

