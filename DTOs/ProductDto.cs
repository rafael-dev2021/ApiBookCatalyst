using APIBookCatalyst.JsonsConvert;
using APIBookCatalyst.ObjectsValue;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.DTOs
{
    public record ProductDto
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonPropertyName("Id")]
        public string? Id { get; set; }

        [JsonPropertyName("Name")]
        [BsonElement("Name")]
        [JsonConverter(typeof(ObjectNameConverter))]
        public ObjectName? Name { get; set; }

        [JsonPropertyName("description")]
        [BsonElement("Description")]
        [JsonConverter(typeof(ObjectDescriptionConverter))]
        public ObjectDescription? Description { get; set; }

        [JsonPropertyName("Image")]
        [BsonElement("Image")]
        [JsonConverter(typeof(ObjectImageConverter))]
        public ObjectImage? Image { get; set; }

        [JsonPropertyName("price")]
        [BsonElement("Price")]
        [JsonConverter(typeof(ObjectPriceConverter))]
        public ObjectPrice? Price { get; set; }

        [JsonPropertyName("Stock")]
        [BsonElement("Stock")]
        [JsonConverter(typeof(ObjectStockConverter))]
        public ObjectStock? Stock { get; set; }
        public bool IsFavorite { get; set; }
        public string? CategoryId { get; set; }

    }
}
