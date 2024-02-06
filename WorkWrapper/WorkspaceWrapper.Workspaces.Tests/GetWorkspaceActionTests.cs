using Moq;
using WorkWrapper.Comms;
using WorkWrapper.Workspaces.Actions;
using WorkWrapper.Workspaces.Models;
using Xunit;

namespace WorkspaceWrapper.Workspaces.Tests;

public class GetWorkspaceActionTests
{
    [Fact]
    public async Task GetWorkspace_UsingId_ReturnsWorkspace()
    {
        //assign
        var dataResponse = new DataResponse<Workspace>
        {
            Data = new() { Id = "ACTIVE!1232.1" }
        };

        var mWorkApiClient = new Mock<IWorkApiClient>();
        mWorkApiClient.Setup(m => m.GetAsync<DataResponse<Workspace>>("workspaces/ACTIVE!1232.1"))
            .ReturnsAsync(dataResponse);

        //act
        var action = new GetWorkspaceAction(mWorkApiClient.Object);
        var document = await action.GetWorkspaceAsync("ACTIVE!1232.1");

        //assert
        Assert.NotNull(document);
    }
}
