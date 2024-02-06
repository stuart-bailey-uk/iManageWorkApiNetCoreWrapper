using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class FolderConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WorkEntityResponse<IFolder>) || objectType == typeof(IFolder);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {            
            var jObject = JObject.Load(reader);            

            var item = jObject["data"] ?? jObject;

            var type = (FolderType)Enum.Parse(typeof(FolderType), item["folder_type"].ToString().Replace("_", ""), true);

            if(objectType == typeof(IFolder))
                return FolderFactory.Create(serializer, item, type);

            var entityResponse = new WorkEntityResponse<IFolder>();

            var response = FolderFactory.Create(serializer, item, type);

            entityResponse.Data = response;

            return entityResponse;
        }        

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}