using Newtonsoft.Json;
using Trinogy.IManage.Rest.WorkApiSettings;

namespace Trinogy.IManage.Core.WorkApiSettings
{
    public static class JsonSettingsFactory
    {
        private static JsonSerializerSettings _settings;

        public static JsonSerializerSettings GetDefaultSettings()
        {
            return _settings ??
                (_settings = new JsonSerializerSettings
                {
                    Converters = Converters(),
                    ContractResolver = new WorkContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        private static JsonConverter[] Converters()
        {
            return new JsonConverter[]
            {
                new NvpsReaderJsonConverter(),
                new NvpsWriterJsonConverter(),
                new WorkStringEnumConverter(),
                new SubscriptionFolderChildConverter(),
                new ShortcutConverter(),
                new FolderListConverter(),
                new FolderConverter(),
                new RelativeDateConverter(),
                new DocumentSearchConverter()
            };
        }
    }
}