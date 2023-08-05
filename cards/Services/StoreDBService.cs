using cards.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cards.Services
{
    public class StoreDBService
    {
        private readonly IMongoCollection<StoreDB> _storeDBCollection;

        public StoreDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase("CardDB");

            _storeDBCollection = database.GetCollection<StoreDB>("StoreDB");

        }

        //Create to StoreDB
        public async Task CreateStoreDB(StoreDB storeDB)
        {
            await _storeDBCollection.InsertOneAsync(storeDB);
            return;
        }

        //Get the StoreDB
        public async Task<List<StoreDB>> GetStoreDB()
        {
            return await _storeDBCollection.Find(new BsonDocument()).ToListAsync();
        }

        //Post to StoreDB
        public async Task AddToStoreDB(string id, string storeDBId)
        {
            FilterDefinition<StoreDB> filter = Builders<StoreDB>.Filter.Eq("Id", id);
            UpdateDefinition<StoreDB> update = Builders<StoreDB>.Update.AddToSet<string>("items", storeDBId);
            await _storeDBCollection.UpdateOneAsync(filter, update);
            return;
        }

        //Delete from StoreDB
        public async Task DeleteStoreDB(string id)
        {
            FilterDefinition<StoreDB> filter = Builders<StoreDB>.Filter.Eq("Id", id);
            await _storeDBCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
