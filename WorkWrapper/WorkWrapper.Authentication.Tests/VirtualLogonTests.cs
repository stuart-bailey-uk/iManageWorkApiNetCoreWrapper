using System.Net;
using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Core.Auth;
using Xunit;

namespace WorkWrapper.Authentication.Tests
{
    public class VirtualLogonTests
    {
        [Fact]
        public async Task VirtualLogin_Success_Returns_Session()
        {
            //assign
            var mWorkApiFactory = new Mock<IWorkApiClientFactory>();

            const string loginResponse = @"{
                                            ""access_token"": ""VCnY0d1BRv7"",
                                            ""expires_in"": 1800,
                                            ""token_type"": ""Bearer"",
                                            ""scope"": ""user"",
                                            ""refresh_token"": ""foobar""
                                        }";

            var responseContent = new StringContent(loginResponse);

            var mHttpClient = new Mock<IHttpClientProxy>();
            mHttpClient.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = responseContent });

            //act
            var logonWrapper = new VirtualLogonTestWrapper(mWorkApiFactory.Object, mHttpClient.Object);
            logonWrapper.ForClient("foo", "bar");
            logonWrapper.ForUser("foo", "bar");
            var sessionObject = logonWrapper.TestLogonAsync();

            //assert
            Assert.NotNull(sessionObject);
        }

        [Fact]
        public async Task VirtualLogin_Failure_Returns_Exception()
        {
            //assign
            var mWorkApiFactory = new Mock<IWorkApiClientFactory>();

            const string loginResponse = @"{
                                            ""error"": {
                                                ""code"": ""LoginFailed"",
                                                ""message"": ""User ID or Password is incorrect""
                                            }
                                        }";

            var responseContent = new StringContent(loginResponse);

            var mHttpClient = new Mock<IHttpClientProxy>();
            mHttpClient.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = responseContent });

            //act
            var logonWrapper = new VirtualLogonTestWrapper(mWorkApiFactory.Object, mHttpClient.Object);
            logonWrapper.ForClient("foo", "bar");
            logonWrapper.ForUser("foo", "bar");

            //assert
            await Assert.ThrowsAsync<WorkApiException>(() => logonWrapper.TestLogonAsync());
        }

        [Fact]
        public async Task VirtualLogin_ForClientNotCalled_Returns_Exception()
        {
            //assign
            var mWorkApiFactory = new Mock<IWorkApiClientFactory>();

            const string loginResponse = @"<html></html>";

            var responseContent = new StringContent(loginResponse);

            var mHttpClient = new Mock<IHttpClientProxy>();
            mHttpClient.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync((HttpRequestMessage request) => new HttpResponseMessage(HttpStatusCode.OK) { Content = responseContent, RequestMessage = request });

            //act
            var logonWrapper = new VirtualLogonTestWrapper(mWorkApiFactory.Object, mHttpClient.Object);
            logonWrapper.ForUser("foo", "bar");

            //assert
            var exception = await Assert.ThrowsAsync<Exception>(() => logonWrapper.TestLogonAsync());

            Assert.Equal($"{nameof(logonWrapper.ForClient)} did not get passed a ClientId or ClientSecret", exception.Message);
        }

        [Fact]
        public async Task VirtualLogin_ForUserNotCalled_Returns_Exception()
        {
            //assign
            var mWorkApiFactory = new Mock<IWorkApiClientFactory>();

            const string loginResponse = @"<html></html>";

            var responseContent = new StringContent(loginResponse);

            var mHttpClient = new Mock<IHttpClientProxy>();
            mHttpClient.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>()))
                .ReturnsAsync((HttpRequestMessage request) => new HttpResponseMessage(HttpStatusCode.OK) { Content = responseContent, RequestMessage = request });

            //act
            var logonWrapper = new VirtualLogonTestWrapper(mWorkApiFactory.Object, mHttpClient.Object);
            logonWrapper.ForClient("foo", "bar");

            //assert
            var exception = await Assert.ThrowsAsync<Exception>(() => logonWrapper.TestLogonAsync());

            Assert.Equal($"{nameof(logonWrapper.ForUser)} did not get passed a Username or Password", exception.Message);
        }


        private class VirtualLogonTestWrapper : VirtualLogon
        {
            internal VirtualLogonTestWrapper(IWorkApiClientFactory workHttpClientFactory, IHttpClientProxy httpClientProxy) : base("http://foo.co.uk/work", httpClientProxy)
            {
            }

            public Task<ISessionToken> TestLogonAsync()
            {
                return GetAuthenticatedResponseAsync();
            }

            protected override Task<ISessionToken> GetAuthenticatedResponseAsync()
            {
                return base.GetAuthenticatedResponseAsync();
            }
        }
    }
}