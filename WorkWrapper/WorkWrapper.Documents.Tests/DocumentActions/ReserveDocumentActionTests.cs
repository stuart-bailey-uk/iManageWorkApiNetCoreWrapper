using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Documents.Actions;
using WorkWrapper.Documents.Models;
using Xunit;

namespace WorkWrapper.Documents.Tests.DocumentActions;

public class ReserveDocumentActionTests
{

    [Fact]
    public async Task ReserveDocument_Success_ReturnsDocumentReservedModel()
    {
        //assign
        var dataResponse = new DataResponse<ReservedDocument>
        {
            Data = new() { DocumentNumber = 1234, Version = 1 }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.GetAsync<DataResponse<ReservedDocument>>("documents/reserve"))
            .ReturnsAsync(dataResponse);

        //act
        var action = new ReserveDocumentAction(mWorkApiClient.Object);
        var document = await action.ReserveDocumentAsync();

        //assert
        Assert.NotNull(document);
    }
}