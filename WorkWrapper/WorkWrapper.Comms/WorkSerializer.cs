using Newtonsoft.Json;
using WorkWrapper.Core.Json;

namespace WorkWrapper.Comms;

public static class WorkSerializer
{
    private static IEnumerable<JsonConverter>? _converters;
    private static JsonSerializerSettings? _settings;

    public static void AddCustomConverters(IEnumerable<JsonConverter> jsonConverters)
    {
        _converters = jsonConverters;

        _settings = CreateSettings();
    }

    public static string SerializeObject(object value)
    {
        return JsonConvert.SerializeObject(value, Settings);
    }

    public static T? DeserializeObject<T>(string json)
    {
        return JsonConvert.DeserializeObject<T>(json, Settings);
    }

    public static JsonSerializerSettings Settings => _settings ??= CreateSettings();

    private static JsonSerializerSettings CreateSettings()
    {
        return new JsonSerializerSettings
        {
            ContractResolver = new WorkJsonContractResolver(),
            Converters = new List<JsonConverter>(_converters ?? Enumerable.Empty<JsonConverter>())
            {
                new WorkEnumConverter()
            },
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}