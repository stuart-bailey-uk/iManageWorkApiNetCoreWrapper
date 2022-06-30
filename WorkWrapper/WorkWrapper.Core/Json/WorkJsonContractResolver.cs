using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WorkWrapper.Core.Json;

public class WorkJsonContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var jsonProperty = base.CreateProperty(member, memberSerialization);

        //Manually Overridden
        if (member.CustomAttributes.Any(a => a.AttributeType == typeof(JsonPropertyAttribute)))
        {
            return base.CreateProperty(member, memberSerialization);
        }

        if(jsonProperty.PropertyName == null)
            return jsonProperty;

        //Set the Json property name to have an '_' where the C# property has an uppercase letter
        var name = Regex.Replace(jsonProperty.PropertyName, "(?<=.)([A-Z])", "_$0", RegexOptions.Compiled);

        jsonProperty.PropertyName = name.ToLower();

        return jsonProperty;
    }
}