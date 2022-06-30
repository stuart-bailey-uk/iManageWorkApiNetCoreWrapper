using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Documents.Actions;
using WorkWrapper.Documents.Models;
using Xunit;

namespace WorkWrapper.Documents.Tests.DocumentActions;

public class GetDocumentProfileTests
{
    [Fact]
    public async Task GetDocumentProfile_ShouldReturnProfile()
    {
        //assign
        var mWorkApiAClient = new Mock<IWorkApiClient>();
        mWorkApiAClient.Setup(m => m.ForLibrary(It.IsAny<string>()))
            .Returns(mWorkApiAClient.Object);
        mWorkApiAClient.Setup(m => m.GetAsync<DataResponse<WorkDocument>>(It.IsAny<string>()))
            .ReturnsAsync((string uri) => new DataResponse<WorkDocument>
                { Data = new WorkDocument { Id = uri.Substring(10) } });

        //act
        var action = new GetDocumentProfileAction(mWorkApiAClient.Object);
        var profile = await action.GetAsync("FOO!1234.1");

        //assert
        Assert.Equal("FOO!1234.1", profile!.Id);
    }

    [Fact]
    public async Task GetDocumentProfile_ShouldCallDocumentsLibrary()
    {
        //assign
        var mWorkApiAClient = new Mock<IWorkApiClient>();
        mWorkApiAClient.Setup(m => m.ForLibrary(It.IsAny<string>()))
            .Returns(mWorkApiAClient.Object);
        mWorkApiAClient.Setup(m => m.GetAsync<DataResponse<WorkDocument>>(It.IsAny<string>()))
            .ReturnsAsync(new DataResponse<WorkDocument>());

        //act
        var action = new GetDocumentProfileAction(mWorkApiAClient.Object);
        var profile = await action.GetAsync("FOO!1234.1");

        //assert
        mWorkApiAClient.Verify(m => m.ForLibrary("FOO"));
    }
}