using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Documents.Actions;
using WorkWrapper.Documents.Models;
using Xunit;

namespace WorkWrapper.Documents.Tests.DocumentActions;

public class CreateDocumentActionTests
{

    [Fact]
    public async Task CreateDocument_Success_ReturnsDocumentReservedModel()
    {
        //assign
        var dataResponse = new DataResponse<WorkDocument>
        {
            Data = new() { Id = "ACTIVE!1232.1" }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.SendAsync<DataResponse<WorkDocument>>(HttpMethod.Post, "folders/ACTIVE!123/documents", It.IsAny<MultipartFormDataContent>()))
            .ReturnsAsync(dataResponse);

        //act
        var docProfile = new WorkDocument
        {
            Name = "FOOBAR",
            Class = "DOC",
            Extension = "pdf"
        };

        var uploadRequest = new DocumentUploadRequest(docProfile)
        {
            InheritProfileFromFolder = true
        };

        using var stream = new MemoryStream();

        var action = new CreateDocumentAction(mWorkApiClient.Object);
        var document = await action.CreateDocumentAsync(uploadRequest, "ACTIVE!123", stream);

        //assert
        Assert.NotNull(document);
    }
}