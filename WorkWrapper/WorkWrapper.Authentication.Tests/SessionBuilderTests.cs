using System.Net;
using Moq;
using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Core.Auth;
using WorkWrapper.Session;
using Xunit;

namespace WorkWrapper.Authentication.Tests;

public class SessionBuilderTests
{
    [Fact]
    public async Task LogonFailure_Returns_Exception()
    {
        //assign
        var mWorkClientFactory = new Mock<IWorkApiClientFactory>();

        //act
        var sessionBuilder = new SessionBuilderTestWrapper(mWorkClientFactory.Object);
        sessionBuilder.SetupResponse(() => throw new WorkApiObjectException("Dummy", "Dummy"));

        //assert
        await Assert.ThrowsAsync<WorkApiObjectException>(() => sessionBuilder.GetSessionAsync());
    }

    [Fact]
    public async Task LogonSuccess_Returns_Session()
    {
        //assign
        const string discoveryResponse = @"{
                                            ""data"": {
                                                ""auth_status"": ""authenticated"",
                                                ""user"": {
                                                    ""customer_id"": 1,
                                                    ""id"": ""IMANADMIN"",
                                                    ""name"": ""IMAN ADMIN"",
                                                    ""email"": ""IMAN.ADMIN@KELTIE.COM""
                                                },                                                
                                                ""work"": {
                                                    ""preferred_library"": ""LIVE"",
                                                    ""libraries"": [
                                                        {
                                                            ""alias"": ""Live"",
                                                            ""type"": ""worksite"",
                                                            ""region"": ""near"",
                                                            ""is_hidden"": false
                                                        }
                                                    ]
                                                }
                                            }
                                        }";

        var message = new HttpResponseMessage
        {
            Content = new StringContent(discoveryResponse)
        };

        var mApi = new Mock<IWorkApiClient>();
        mApi.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
            .ReturnsAsync(message);

        var mWorkClientFactory = new Mock<IWorkApiClientFactory>();
        mWorkClientFactory.Setup(m => m.Create(It.IsAny<ISession>()))
            .Returns(mApi.Object);

        var mSessionToken = new Mock<ISessionToken>();
        mSessionToken.SetupAllProperties();

        //act
        var sessionBuilder = new SessionBuilderTestWrapper(mWorkClientFactory.Object);
        sessionBuilder.SetupResponse(() => mSessionToken.Object);
        var session = await sessionBuilder.GetSessionAsync();

        //assert
        Assert.Equal("1", session.CustomerId);
        Assert.Equal("LIVE", session.PreferredLibrary);
    }

    private class SessionBuilderTestWrapper : SessionBuilder
    {
        private Func<ISessionToken> _response;

        internal SessionBuilderTestWrapper(IWorkApiClientFactory workHttpClientFactory) : base("http://foo.co.uk/work", workHttpClientFactory)
        {
        }

        public void SetupResponse(Func<ISessionToken> func)
        {
            _response = func;
        }

        protected override Task<ISessionToken> GetAuthenticatedResponseAsync()
        {
            return Task.FromResult(_response());
        }
    }

}