using APIBookCatalyst.JsonsConvert;
using APIBookCatalyst.ObjectsValue;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.DTOs
{
    public record CategoryDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [JsonPropertyName("Name")]
        [BsonElement("Name")]
        [JsonConverter(typeof(ObjectNameConverter))]
        public ObjectName? Name { get; set; }

        [JsonPropertyName("Image")]
        [BsonElement("Image")]
        [JsonConverter(typeof(ObjectImageConverter))]
        public ObjectImage? Image { get; set; }

    }
}
