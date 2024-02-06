using System;
using Newtonsoft.Json;

namespace Trinogy.IManage.Core.WorkApiSettings
{
    internal class WorkStringEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>) && Nullable.GetUnderlyingType(objectType).IsEnum);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var calculatedEnum = objectType;
            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
                calculatedEnum = Nullable.GetUnderlyingType(objectType);

            return Enum.Parse(calculatedEnum, reader.Value.ToString().Replace("_", ""), true);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var name = System.Text.RegularExpressions.Regex.Replace(value.ToString(), "(?<=.)([A-Z])", "_$0", System.Text.RegularExpressions.RegexOptions.Compiled);

            writer.WriteValue(name.ToLower());            
        }
    }
}