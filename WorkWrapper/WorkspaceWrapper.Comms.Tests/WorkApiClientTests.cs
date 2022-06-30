using System.Text;
using Moq;
using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Core.Models;
using WorkWrapper.Session;
using Xunit;

namespace WorkspaceWrapper.Comms.Tests;

public class WorkApiClientTests
{
    internal class DummyResponse
    {
        public string UserId { get; set; }

        [JsonProperty("wstype")]
        public WsType? Type { get; set; }
    }

    [Fact]
    public async Task SendAsyncMadeWithToken_ReturnsSuccess()
    {
        //assign
        var mSession = new Mock<ISession>();
        mSession.Setup(m => m.Token.AccessToken)
            .Returns("inlutfgrdctsrctdc");
        mSession.Setup(m => m.CustomerId).Returns("1");

        var mClientProxy = new Mock<IHttpClientProxy>();
        mClientProxy.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(new HttpResponseMessage { Content = new StringContent("{ \"user_id\" : \"foo\" }", Encoding.UTF8, "application/json")});

        //act
        var apiClient = new WorkApiClient(mSession.Object, mClientProxy.Object);
        var response = await apiClient.GetAsync<DummyResponse>("documents");

        //assert
        mClientProxy.Verify(m => m.SendAsync(
            It.Is<HttpRequestMessage>(m =>
                m.Headers.Any(message => message.Key == "X-Auth-Token" && message.Value.Contains("inlutfgrdctsrctdc"))
            )));
    }

    [Fact]
    public async Task GetAsyncPreferredLibrary_ReturnsSuccess()
    {
        //assign
        var mSession = new Mock<ISession>();
        mSession.Setup(m => m.Token.AccessToken)
            .Returns("inlutfgrdctsrctdc");
        mSession.Setup(m => m.PreferredLibrary).Returns("Active");
        mSession.Setup(m => m.CustomerId).Returns("1");

        string calledUri = string.Empty;

        var mClientProxy = new Mock<IHttpClientProxy>();
        mClientProxy.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .Callback<HttpRequestMessage>(m => calledUri = m.RequestUri.ToString())
            .ReturnsAsync(new HttpResponseMessage { Content = new StringContent("{ \"user_id\" : \"foo\" }", Encoding.UTF8, "application/json") });

        //act
        var apiClient = new WorkApiClient(mSession.Object, mClientProxy.Object);
        var response = await apiClient.ForPreferredLibrary().GetAsync<DummyResponse>("user");

        //assert
        mClientProxy.Verify(m => m.SendAsync(It.Is<HttpRequestMessage>(m => m.Method == HttpMethod.Get)));
        Assert.Equal("/api/v2/customers/1/libraries/Active/user", calledUri);
    }

    [Fact]
    public async Task GetAsyncHandleUriDoubleSlash_ReturnsSuccess()
    {
        //assign
        var mSession = new Mock<ISession>();
        mSession.Setup(m => m.Token.AccessToken)
            .Returns("inlutfgrdctsrctdc");
        mSession.Setup(m => m.PreferredLibrary).Returns("Active");
        mSession.Setup(m => m.CustomerId).Returns("1");

        string calledUri = string.Empty;

        var mClientProxy = new Mock<IHttpClientProxy>();
        mClientProxy.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .Callback<HttpRequestMessage>(m => calledUri = m.RequestUri.ToString())
            .ReturnsAsync(new HttpResponseMessage { Content = new StringContent("{ \"user_id\" : \"foo\" }", Encoding.UTF8, "application/json") });

        //act
        var apiClient = new WorkApiClient(mSession.Object, mClientProxy.Object);
        var response = await apiClient.ForPreferredLibrary().GetAsync<DummyResponse>("/user");

        //assert
        Assert.Equal("/api/v2/customers/1/libraries/Active/user", calledUri);
    }

    [Fact]
    public async Task GetAsyncWorkException_ThrowsWorkApiException()
    {
        //assign
        var mSession = new Mock<ISession>();
        mSession.Setup(m => m.Token.AccessToken)
            .Returns("inlutfgrdctsrctdc");
        mSession.Setup(m => m.PreferredLibrary).Returns("Active");

        string calledUri = string.Empty;

        var mClientProxy = new Mock<IHttpClientProxy>();
        mClientProxy.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest));

        //act
        var apiClient = new WorkApiClient(mSession.Object, mClientProxy.Object);

        //assert
        await Assert.ThrowsAsync<WorkApiException>(() => apiClient.ForPreferredLibrary().GetAsync<DummyResponse>("/user"));
    }

    [Fact]
    public async Task SendAsyncWithAlternative_ReturnsSuccess()
    {
        //assign
        var mSession = new Mock<ISession>();
        mSession.Setup(m => m.Token.AccessToken)
            .Returns("inlutfgrdctsrctdc");

        var mClientProxy = new Mock<IHttpClientProxy>();
        mClientProxy.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(new HttpResponseMessage { Content = new StringContent("{ \"user_id\" : \"foo\" }", Encoding.UTF8, "application/json") });

        //act
        var apiClient = new WorkApiClient(mSession.Object, mClientProxy.Object)
            .ForLibrary("BAR");
        var response = await apiClient.GetAsync<DummyResponse>("documents");

        //assert
        mClientProxy.Verify(m => m.SendAsync(It.Is<HttpRequestMessage>(m => m.RequestUri.ToString().Contains("/BAR/"))));
    }

    [Fact]
    public async Task SendAsync_DeserializeEnum()
    {
        //assign
        var mSession = new Mock<ISession>();
        mSession.Setup(m => m.Token.AccessToken)
            .Returns("inlutfgrdctsrctdc");
        mSession.Setup(m => m.CustomerId).Returns("1");

        var mClientProxy = new Mock<IHttpClientProxy>();
        mClientProxy.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(new HttpResponseMessage { Content = new StringContent("{ \"user_id\" : \"foo\", \"wstype\" : \"user\" }", Encoding.UTF8, "application/json") });

        //act
        var apiClient = new WorkApiClient(mSession.Object, mClientProxy.Object);
        var response = await apiClient.GetAsync<DummyResponse>("documents");

        //assert
        Assert.Equal(WsType.User, response.Type);
    }
}