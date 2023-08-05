using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace cards.Models
{
    [BsonIgnoreExtraElements]
    public class PurchaseCreditDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public double ProductTag { get; set; }

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string>? purchase { get; set; }

        //To be done Later
    }
}
