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

public class FlattenJsonConverter : JsonConverter
{
    /// <summary>Writes the JSON representation of the object.</summary>
    /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
    /// <param name="value">The value.</param>
    /// <param name="serializer">The calling serializer.</param>
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value == null)
            return;

        var properties = value.GetType().GetProperties();

        foreach (var property in properties)
        {
            writer.WritePropertyName(property.Name);
            writer.WriteValue(property.GetValue(value));
        }

    }

    /// <summary>Reads the JSON representation of the object.</summary>
    /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
    /// <param name="objectType">Type of the object.</param>
    /// <param name="existingValue">The existing value of object being read.</param>
    /// <param name="serializer">The calling serializer.</param>
    /// <returns>The object value.</returns>
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    /// <param name="objectType">Type of the object.</param>
    /// <returns>
    /// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanConvert(Type objectType)
    {
        return true;
    }
}