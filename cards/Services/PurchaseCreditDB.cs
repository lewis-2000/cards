using cards.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cards.Services
{
    public class PurchaseCreditDB
    {
        private readonly IMongoCollection<PurchaseCreditDB> _purchaseCollection;

        public PurchaseCreditDB(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase("CardDB");

            _purchaseCollection = database.GetCollection<PurchaseCreditDB>("PurchaseCredit");

        }

        public async Task CreateCard(PurchaseCreditDB purchaseCredit)
        {
            await _purchaseCollection.InsertOneAsync(purchaseCredit);
            return;
        }

        public async Task<List<PurchaseCreditDB>> GetCardDB()
        {
            return await _purchaseCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddToCardDB(string id, string purchaseCreditId)
        {
            FilterDefinition<PurchaseCreditDB> filter = Builders<PurchaseCreditDB>.Filter.Eq("Id", id);
            UpdateDefinition<PurchaseCreditDB> update = Builders<PurchaseCreditDB>.Update.AddToSet<string>("items", purchaseCreditId);
            await _purchaseCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteCardDB(string id)
        {
            FilterDefinition<PurchaseCreditDB> filter = Builders<PurchaseCreditDB>.Filter.Eq("Id", id);
            await _purchaseCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
