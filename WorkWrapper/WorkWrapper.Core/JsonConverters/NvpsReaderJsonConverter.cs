using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class NvpsReaderJsonConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var nvpList = new WorkCollectionResponse<NameValuePair>(); ;

            var jObject = JObject.Load(reader);

            var nvpsData = new List<NameValuePair>();
            foreach (var item in jObject["data"])
            {
                var prop = item as JProperty;

                nvpsData.Add(new NameValuePair
                {
                    Key = prop.Name,
                    Value = prop.Value.ToString()
                });
            }

            nvpList.Data = nvpsData.Any() ? nvpsData : null;

            return nvpList;
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(WorkCollectionResponse<NameValuePair>))
            {
                return true;
            }

            return false;
        }
    }
}