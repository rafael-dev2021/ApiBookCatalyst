using APIBookCatalyst.ObjectsValue;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.JsonsConvert
{
    public class ObjectStockConverter : JsonConverter<ObjectStock>
    {
        public override ObjectStock Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetInt32(out int stock))
            {
                return new ObjectStock(stock);
            }

            throw new JsonException("Unable to deserialize ObjectStock.");
        }

        public override void Write(Utf8JsonWriter writer, ObjectStock value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Stock);
        }
    }
}
