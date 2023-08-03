using cards.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cards.Services
{
    public class DiscoverDBService
    {
        private readonly IMongoCollection<DiscoverDB> _discoverDBCollection;

        public DiscoverDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase("CardDB");

            _discoverDBCollection = database.GetCollection<DiscoverDB>("DiscoverDB");

        }

        public async Task CreateCard(DiscoverDB discover)
        {
            await _discoverDBCollection.InsertOneAsync(discover);
            return;
        }

        public async Task<List<DiscoverDB>> GetCardDB()
        {
            return await _discoverDBCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToCardDB(string id, string purchaseCreditId)
        {
            FilterDefinition<DiscoverDB> filter = Builders<DiscoverDB>.Filter.Eq("Id", id);
            UpdateDefinition<DiscoverDB> update = Builders<DiscoverDB>.Update.AddToSet<string>("items", purchaseCreditId);
            await _discoverDBCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteCardDB(string id)
        {
            FilterDefinition<DiscoverDB> filter = Builders<DiscoverDB>.Filter.Eq("Id", id);
            await _discoverDBCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
