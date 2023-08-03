using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace CardsLandingPage.Models
{
    public class Card
    {
        public string Name { get; set; } = null!;

        public string PseudoName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime JoinDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string> ItemId { get; set; } = null!;

        public double Credit { get; set; }

        public string Description { get; set; } = null!;
    }
}
