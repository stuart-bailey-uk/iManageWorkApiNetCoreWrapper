using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Trinogy.IManage.Rest.WorkApiSettings
{
    public class WorkContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            if (member.DeclaringType == typeof(Token) && prop.ToString() == "X-Auth-Token")
            {
                prop.PropertyName = "X-Auth-Token";
                return prop;
            }

            prop.PropertyName = prop.PropertyName.Replace('.', '_');

            var name = System.Text.RegularExpressions.Regex.Replace(prop.PropertyName, "(?<=.)([A-Z])", "_$0", System.Text.RegularExpressions.RegexOptions.Compiled);

            prop.PropertyName = name.ToLower();

            return prop;
        }
    }
}