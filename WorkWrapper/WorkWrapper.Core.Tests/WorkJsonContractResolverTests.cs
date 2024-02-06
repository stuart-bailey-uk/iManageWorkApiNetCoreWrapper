using System.Reflection;
using Newtonsoft.Json;
using Xunit;
using Newtonsoft.Json.Serialization;
using WorkWrapper.Core.Json;

namespace WorkWrapper.Core.Tests;

public class WorkJsonContractResolverTests
{
    [Fact]
    public void Map_iManageUnderscoreToPropertyName()
    {
        //assign
        var type = typeof(ResolvedDummy);

        var member = type.GetMember("PreferredLibrary");

        //act
        var contractResolver = new TestableContractResolver();
        var jsonProperty = contractResolver.TestProperty(member[0], MemberSerialization.OptOut);

        //assert
        Assert.Equal("preferred_library", jsonProperty.PropertyName);
    }

    [Fact]
    public void Map_iManageUnderscoreToPropertyName_IgnoreToken()
    {
        //assign
        var type = typeof(ResolvedDummy);

        var member = type.GetMember("NoCamelCase");

        //act
        var contractResolver = new TestableContractResolver();
        var jsonProperty = contractResolver.TestProperty(member[0], MemberSerialization.OptOut);

        //assert
        Assert.Equal("nocamelCase", jsonProperty.PropertyName);
    }


    internal class TestableContractResolver : WorkJsonContractResolver
    {
        public JsonProperty TestProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            return base.CreateProperty(member, memberSerialization);
        }

    }

    internal class ResolvedDummy
    {
        public string PreferredLibrary{ get; set; }

        [JsonProperty("nocamelCase")]
        public string NoCamelCase{ get; set; }
    }
}