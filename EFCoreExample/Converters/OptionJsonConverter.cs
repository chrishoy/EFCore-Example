using LanguageExt;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace EFCoreExample.Converters;

public class OptionJsonConverter<T> : JsonConverter<Option<T>>
{
    public override Option<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = JsonSerializer.Deserialize<T>(ref reader, options);
        return value is not null ? Option<T>.Some(value) : Option<T>.None;
    }

    public override void Write(Utf8JsonWriter writer, Option<T> value, JsonSerializerOptions options)
    {
        value.Match(
            Some: v => JsonSerializer.Serialize(writer, v, options),
            None: () => writer.WriteNullValue()
        );
    }
}
