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

        //Create to DiscoverDB
        public async Task CreateDiscoverDB(DiscoverDB discover)
        {
            await _discoverDBCollection.InsertOneAsync(discover);
            return;
        }

        //Get the DiscoverDB
        public async Task<List<DiscoverDB>> GetDiscoverCardDB()
        {
            return await _discoverDBCollection.Find(new BsonDocument()).ToListAsync();
        }

        //Post to DiscoverDB
        public async Task AddToDiscoverDB(string id, string purchaseCreditId)
        {
            FilterDefinition<DiscoverDB> filter = Builders<DiscoverDB>.Filter.Eq("Id", id);
            UpdateDefinition<DiscoverDB> update = Builders<DiscoverDB>.Update.AddToSet<string>("items", purchaseCreditId);
            await _discoverDBCollection.UpdateOneAsync(filter, update);
            return;
        }

        //Delete from DiscoverDB
        public async Task DeleteDiscoverDB(string id)
        {
            FilterDefinition<DiscoverDB> filter = Builders<DiscoverDB>.Filter.Eq("Id", id);
            await _discoverDBCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
