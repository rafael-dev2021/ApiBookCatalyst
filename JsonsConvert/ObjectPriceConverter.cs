using APIBookCatalyst.ObjectsValue;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.JsonsConvert
{
    public class ObjectPriceConverter : JsonConverter<ObjectPrice>
    {
        public override ObjectPrice Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetDecimal(out decimal price))
            {
                return new ObjectPrice(price);
            }

            throw new JsonException("Unable to deserialize ObjectPrice.");
        }

        public override void Write(Utf8JsonWriter writer, ObjectPrice value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Price);
        }
    }
}
