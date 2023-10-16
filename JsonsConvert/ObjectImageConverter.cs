using APIBookCatalyst.ObjectsValue;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIBookCatalyst.JsonsConvert
{
    public class ObjectImageConverter : JsonConverter<ObjectImage>
    {
        public override ObjectImage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return new ObjectImage { Image = reader.GetString() };
            }

            throw new JsonException("Unable to deserialize ObjectImage.");
        }

        public override void Write(Utf8JsonWriter writer, ObjectImage value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Image);
        }
    }
}
