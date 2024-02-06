using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Documents.Actions;
using WorkWrapper.Documents.Models;
using Xunit;

namespace WorkWrapper.Documents.Tests.DocumentActions;

public class GetDocumentActionTests
{
    [Fact]
    public async Task GetDocument_Success_ReturnsDocument()
    {
        //assign
        var dataResponse = new DataResponse<WorkDocument>
        {
            Data = new() { Id = "ACTIVE!1232.1" }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.GetAsync<DataResponse<WorkDocument>>("documents/ACTIVE!1232.1"))
            .ReturnsAsync(dataResponse);

        //act
        var action = new GetDocumentAction(mWorkApiClient.Object);
        var document = await action.GetDocumentAsync("ACTIVE!1232.1");

        //assert
        Assert.NotNull(document);
    }

    [Fact]
    public async Task GetDocument_GetLatest_AddsQuery()
    {
        //assign
        var dataResponse = new DataResponse<WorkDocument>
        {
            Data = new() { Id = "ACTIVE!1232.1" }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.GetAsync<DataResponse<WorkDocument>>(It.IsAny<string>()))
            .ReturnsAsync(dataResponse);

        //act
        var action = new GetDocumentAction(mWorkApiClient.Object).GetLatest();
        var document = await action.GetDocumentAsync("ACTIVE!1232.1");

        //assert
        Assert.NotNull(document);
        mWorkApiClient.Verify(m =>
            m.GetAsync<DataResponse<WorkDocument>>(It.Is<string>(s => s.Contains("is_latest=true"))));
    }

    [Fact]
    public async Task GetDocument_IncludeOperations_AddsQuery()
    {
        //assign
        var dataResponse = new DataResponse<WorkDocument>
        {
            Data = new() { Id = "ACTIVE!1232.1" }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.GetAsync<DataResponse<WorkDocument>>(It.IsAny<string>()))
            .ReturnsAsync(dataResponse);

        //act
        var action = new GetDocumentAction(mWorkApiClient.Object).IncludeOperations();
        var document = await action.GetDocumentAsync("ACTIVE!1232.1");

        //assert
        Assert.NotNull(document);
        mWorkApiClient.Verify(m =>
            m.GetAsync<DataResponse<WorkDocument>>(It.Is<string>(s => s.Contains("include_operations=true"))));
    }

    [Fact]
    public async Task GetDocument_AddParentId_AddsQuery()
    {
        //assign
        var dataResponse = new DataResponse<WorkDocument>
        {
            Data = new() { Id = "ACTIVE!1232.1" }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.GetAsync<DataResponse<WorkDocument>>(It.IsAny<string>()))
            .ReturnsAsync(dataResponse);

        //act
        var action = new GetDocumentAction(mWorkApiClient.Object).ParentId("ACTIVE!4");
        var document = await action.GetDocumentAsync("ACTIVE!1232.1");

        //assert
        Assert.NotNull(document);
        mWorkApiClient.Verify(m =>
            m.GetAsync<DataResponse<WorkDocument>>(It.Is<string>(s => s.Contains("parent_id=ACTIVE!4"))));
    }
}