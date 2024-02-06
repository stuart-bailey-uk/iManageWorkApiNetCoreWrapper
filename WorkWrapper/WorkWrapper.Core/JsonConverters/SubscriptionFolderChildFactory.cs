using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Trinogy.IManage.Core.Models;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class SubscriptionFolderChildFactory
    {
        public static ISubscriptionFolderChild Create(JsonSerializer serializer, JToken item, object type)
        {
            ISubscriptionFolderChild subscriptionItem = null; ;
            switch (type)
            {
                case WsType.WorkspaceShortcut:
                    subscriptionItem = new WorkspaceShortcut();
                    break;
                case WsType.DocumentShortcut:
                    subscriptionItem = new DocumentShortcut();
                    break;
                case WsType.Folder:
                    var folderType = Enum.Parse(typeof(FolderType), item["folder_type"].ToString().Replace("_", ""), true);
                    switch (folderType)
                    {
                        case FolderType.Category:
                            subscriptionItem = new Category();
                            break;
                        default:
                            subscriptionItem = new UnknownTypeShortcut();
                            break;
                    }
                    break;
                default:
                    subscriptionItem = new UnknownTypeShortcut();
                    break;
            }

            if (subscriptionItem != null)
            {
                serializer.Populate(item.CreateReader(), subscriptionItem);
            }

            return subscriptionItem;
        }
    }
}