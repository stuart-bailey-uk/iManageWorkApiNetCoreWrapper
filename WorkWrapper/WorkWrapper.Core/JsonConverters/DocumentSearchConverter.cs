using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class DocumentSearchConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WorkCollectionResponse<Document>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var response = new WorkCollectionResponse<Document>() { Data = new List<Document>(), TotalCount = (int?)jObject["total_count"] };

            var data = jObject["data"];

            if(data is JObject jData && jData.ContainsKey("results"))
            {
                data = data["results"];
            }

            foreach (var item in data)
            {
                response.Data.Add(item.ToObject<Document>());
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}