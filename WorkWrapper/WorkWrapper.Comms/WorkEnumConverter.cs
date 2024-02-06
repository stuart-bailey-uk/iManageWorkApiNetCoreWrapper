using Newtonsoft.Json;

namespace WorkWrapper.Comms;

internal class WorkEnumConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        var enumValue = value?.ToString();

        if (enumValue == null)
            return;

        var name = System.Text.RegularExpressions.Regex.Replace(enumValue, "(?<=.)([A-Z])", "_$0", System.Text.RegularExpressions.RegexOptions.Compiled);

        writer.WriteValue(name.ToLower());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var enumType = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>)
            ? Nullable.GetUnderlyingType(objectType)
            : objectType;

        if (enumType == null)
            return null;

        var enumValue = reader.Value?.ToString();

        if(enumValue == null)
            return null;

        return Enum.Parse(enumType, enumValue.Replace("_", ""), true);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType.IsEnum || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) && (Nullable.GetUnderlyingType(objectType)?.IsEnum ?? false));
    }
}