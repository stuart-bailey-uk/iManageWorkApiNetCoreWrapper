using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class ShortcutConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WorkEntityResponse<IShortcut>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var response = new WorkEntityResponse<IShortcut>();

            var item = jObject["data"];

            var type = Enum.Parse(typeof(WsType), item["wstype"].ToString().Replace("_", ""), true);

            ISubscriptionFolderChild subscriptionFolderChild = SubscriptionFolderChildFactory.Create(serializer, item, type);            

            if (subscriptionFolderChild is IShortcut shortcut)
            {                
                response.Data = shortcut;
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }
    }
}