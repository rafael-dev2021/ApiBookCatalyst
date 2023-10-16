using APIBookCatalyst.ObjectsValue;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.JsonsConvert
{
    public class ObjectNameConverter : JsonConverter<ObjectName>
    {
        public override ObjectName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new ObjectName(reader.GetString());
            }

            throw new JsonException("Unable to deserialize ObjectName.");
        }

        public override void Write(Utf8JsonWriter writer, ObjectName value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Name);
        }
    }
}
