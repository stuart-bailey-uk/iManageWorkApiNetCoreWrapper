using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class FolderFactory
    {
        public static IFolder Create(JsonSerializer serializer, JToken item, FolderType type)
        {
            IFolder folder = null; ;
            switch (type)
            {
                case FolderType.Regular:
                    folder = new DocumentFolder();
                    break;
                case FolderType.Search:
                    folder = new SearchFolder();
                    break;
                case FolderType.Tab:
                    folder = new Tab();
                    break;                    
                default:
                    folder = new DocumentFolder();
                    break;
            }

            if (folder != null)
            {
                serializer.Populate(item.CreateReader(), folder);                
            }

            return folder;
        }
    }
}