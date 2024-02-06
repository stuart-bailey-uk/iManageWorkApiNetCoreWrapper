using System.Reflection.Metadata;
using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Workspaces.Models;

namespace WorkWrapper.Workspaces.Actions;

public class GetWorkspaceAction : IGetWorkspaceAction
{
    private readonly IWorkApiClient _workApiClient;

    public GetWorkspaceAction(IWorkApiClient workApiClient)
    {
        _workApiClient = workApiClient;
    }

    /// <inheritdoc />
    public async Task<IDataResponse<Workspace>> GetWorkspaceAsync(string workspaceId)
    {
        var workspaceResponse = await _workApiClient.GetAsync<DataResponse<Workspace>>($"workspaces/{workspaceId}");

        return workspaceResponse;
    }
}

public interface IGetWorkspaceAction
{
    /// <summary>
    /// Gets a workspace
    /// </summary>
    /// <param name="workspaceId"></param>
    /// <returns></returns>
    public Task<IDataResponse<Workspace>> GetWorkspaceAsync(string workspaceId);
}