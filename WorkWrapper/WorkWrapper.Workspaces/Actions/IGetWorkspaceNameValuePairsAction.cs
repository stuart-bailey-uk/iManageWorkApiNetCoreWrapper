using WorkWrapper.Comms;

namespace WorkWrapper.Workspaces.Actions;

public interface IGetWorkspaceNameValuePairsAction
{
    /// <summary>
    /// Gets a workspace's name value pairs
    /// </summary>
    /// <param name="workspaceId"></param>
    /// <returns></returns>
    public Task<IDataResponse<Dictionary<string, string>>> GetNameValuePairsAsync(string workspaceId);
}