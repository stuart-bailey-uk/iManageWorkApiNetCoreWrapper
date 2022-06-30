using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Session;
using Xunit;

namespace WorkspaceWrapper.Comms.Tests
{
    public class WorkHttpClientFactoryTests
    {
        [Fact]
        public void CreateProxySuccess()
        {
            //assign
            var mSession = new Mock<ISession>();

            //act
            var factory = new WorkApiClientFactory();
            var proxy = factory.Create(mSession.Object);

            //assert
            Assert.NotNull(proxy);
        }
    }
}
