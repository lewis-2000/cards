using cards.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace cards.Services
{
    public class PurchaseCreditDBService
    {
        private readonly IMongoCollection<PurchaseCreditDB> _purchaseCollection;

        public PurchaseCreditDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase("CardDB");

            _purchaseCollection = database.GetCollection<PurchaseCreditDB>("PurchaseCredit");

        }

        //Create Purchace PurchceCreditDB
        public async Task CreatePurchceCreditDB(PurchaseCreditDB purchaseCredit)
        {
            await _purchaseCollection.InsertOneAsync(purchaseCredit);
            return;
        }

        //Get PurchaceCreditDB
        public async Task<List<PurchaseCreditDB>> GetPurchceCreditDB()
        {
            return await _purchaseCollection.Find(new BsonDocument()).ToListAsync();
        }


        //Add to PurchceCreditDB
        public async Task AddToPurchceCreditDB(string id, string purchaseCreditId)
        {
            FilterDefinition<PurchaseCreditDB> filter = Builders<PurchaseCreditDB>.Filter.Eq("Id", id);
            UpdateDefinition<PurchaseCreditDB> update = Builders<PurchaseCreditDB>.Update.AddToSet<string>("items", purchaseCreditId);
            await _purchaseCollection.UpdateOneAsync(filter, update);
            return;
        }

        //Delete from PurchceCreditDB
        public async Task DeletePurchceCreditDB(string id)
        {
            FilterDefinition<PurchaseCreditDB> filter = Builders<PurchaseCreditDB>.Filter.Eq("Id", id);
            await _purchaseCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
