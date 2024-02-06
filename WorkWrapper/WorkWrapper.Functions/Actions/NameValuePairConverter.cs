using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorkWrapper.Comms;
using WorkWrapper.Functions.Models;

namespace WorkWrapper.Functions.Actions;

public class NameValuePairConverter : JsonConverter
{
    public override bool CanWrite => false;

    public override bool CanRead => true;

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var jObject = JObject.Load(reader);

        var data = jObject["data"];

        if (data == null)
            return null;

        var pairs = data.Select(item => item as JProperty)
            .Select(prop => new NameValuePair(prop!.Name, prop.Value.ToString())).ToList();

        return new DataResponse<List<NameValuePair>>
        {
            Data = pairs
        };
    }

    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DataResponse<List<NameValuePair>>);
    }
}