using cards.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;

namespace cards.Services
{
    public class MongoDBService
    {
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) 
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);

            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        }
    }
}
