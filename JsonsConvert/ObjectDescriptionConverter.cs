using APIBookCatalyst.ObjectsValue;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.JsonsConvert
{
    public class ObjectDescriptionConverter : JsonConverter<ObjectDescription>
    {
        public override ObjectDescription? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new ObjectDescription(reader.GetString());
            }
            throw new JsonException("Unable to deserialize ObjectDescription.");
        }
        public override void Write(Utf8JsonWriter writer, ObjectDescription value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Description);
        }
    }
}
