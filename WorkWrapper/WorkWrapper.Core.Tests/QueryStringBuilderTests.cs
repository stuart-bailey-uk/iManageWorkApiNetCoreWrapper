using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WorkWrapper.Core.Tests
{
    public class QueryStringBuilderTests
    {
        [Fact]
        public void QueryStringBuilder_HasQuery_ReturnsTrue()
        {
            //act
            var queryStringBuilder = new QueryStringBuilder()
                .AddOrUpdate("test", "value");

            //assert
            Assert.True(queryStringBuilder.HasQuery);
        }

        [Fact]
        public void QueryStringBuilder_ToString_ReturnsSingleValue()
        {
            //act
            var queryStringBuilder = new QueryStringBuilder()
                .AddOrUpdate("test", "value");

            var result = queryStringBuilder.ToString();

            //assert
            Assert.Equal("?test=value", result);
        }

        [Fact]
        public void QueryStringBuilder_ToString_ReturnsMultipleValue()
        {
            //act
            var queryStringBuilder = new QueryStringBuilder()
                .AddOrUpdate("test", "value")
                .AddOrUpdate("test2", "value2");

            var result = queryStringBuilder.ToString();

            //assert
            Assert.Equal("?test=value&test2=value2", result);
        }

        [Fact]
        public void QueryStringBuilder_ReplaceValue_ReturnsUpdatedValue()
        {
            //act
            var queryStringBuilder = new QueryStringBuilder()
                .AddOrUpdate("test", "value")
                .AddOrUpdate("test2", "value2");

            queryStringBuilder.AddOrUpdate("test", "update");

            var result = queryStringBuilder.ToString();

            //assert
            Assert.Equal("?test=update&test2=value2", result);
        }

        [Fact]
        public void QueryStringBuilder_AddsExisting_ReturnsExistingValue()
        {
            //act
            var queryStringBuilder = new QueryStringBuilder()
                .AddOrUpdate("test", "value")
                .AddOrUpdate("test", "value");

            var result = queryStringBuilder.ToString();

            //assert
            Assert.Equal("?test=value", result);
        }

        [Fact]
        public void QueryStringBuilder_RemoveValue_DoesNotReturnValue()
        {
            //act
            var queryStringBuilder = new QueryStringBuilder()
                .AddOrUpdate("test", "value")
                .AddOrUpdate("test2", "value2");

            queryStringBuilder.Remove("test");

            var result = queryStringBuilder.ToString();

            //assert
            Assert.Equal("?test2=value2", result);
        }
    }
}
