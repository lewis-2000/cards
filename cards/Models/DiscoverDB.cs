using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace cards.Models
{
    [BsonIgnoreExtraElements]
    public class DiscoverDB
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public string ProductType { get; set; } = null!;

        public float CurrentTag { get; set; }

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public float PreviousTag { get; set; }

        public int SellerReputation { get; set; }

    }
}
