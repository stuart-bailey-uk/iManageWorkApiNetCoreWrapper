using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class SubscriptionFolderChildConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WorkCollectionResponse<ISubscriptionFolderChild>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var response = new WorkCollectionResponse<ISubscriptionFolderChild>() { Data = new List<ISubscriptionFolderChild>(), TotalCount = (int?)jObject["total_count"] };

            foreach (var item in jObject["data"])
            {
                var type = Enum.Parse(typeof(WsType), item["wstype"].ToString().Replace("_", ""), true);

                ISubscriptionFolderChild subscriptionItem = SubscriptionFolderChildFactory.Create(serializer, item, type);

                response.Data.Add(subscriptionItem);
            }

            return response;
        }        

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}