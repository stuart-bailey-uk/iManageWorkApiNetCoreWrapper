using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class FolderListConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WorkCollectionResponse<IFolder>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var response = new WorkCollectionResponse<IFolder>() { Data = new List<IFolder>(), TotalCount = (int?)jObject["total_count"] };

            foreach (var item in jObject["data"])
            {
                var type = (FolderType)Enum.Parse(typeof(FolderType), item["folder_type"].ToString().Replace("_", ""), true);

                var folder = FolderFactory.Create(serializer, item, type);

                response.Data.Add(folder);
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}