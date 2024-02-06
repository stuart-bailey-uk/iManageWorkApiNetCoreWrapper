using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class NvpsWriterJsonConverter : JsonConverter
    {
        public override bool CanRead => false;
        public override bool CanWrite => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var nvp = value as NameValuePair;

            writer.WriteStartObject();
            writer.WritePropertyName(nvp.Key);
            writer.WriteValue(nvp.Value);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(NameValuePair))
            {
                return true;
            }

            return false;
        }
    }
}