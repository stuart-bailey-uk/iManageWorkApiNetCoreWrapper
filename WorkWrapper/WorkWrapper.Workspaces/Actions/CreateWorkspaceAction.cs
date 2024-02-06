using WorkWrapper.Comms;
using WorkWrapper.Workspaces.Models;

namespace WorkWrapper.Workspaces.Actions;

public class CreateWorkspaceAction : ICreateWorkspaceAction
{
    public CreateWorkspaceAction(IWorkApiClient workApiClient)
    {

    }


    /// <inheritdoc />
    public Task<DataResponse<Workspace>> CreateWorkspaceAsync(IWorkspaceCreateStrategy? workspaceCreateStrategy)
    {
        throw new NotImplementedException();
    }
}

public interface ICreateWorkspaceAction
{
    /// <summary>
    /// Create a workspace using the provided strategy
    /// </summary>
    /// <param name="workspaceCreateStrategy"></param>
    /// <returns></returns>
    Task<DataResponse<Workspace>> CreateWorkspaceAsync(IWorkspaceCreateStrategy? workspaceCreateStrategy);
}

public interface IWorkspaceCreateStrategy
{
    Task<IWorkspaceProfile> GetProfile();
}

public class WithProfileStrategy : IWorkspaceCreateStrategy
{
    private readonly IWorkspaceProfile _workspaceProfile;

    public WithProfileStrategy(IWorkspaceProfile workspaceProfile)
    {
        _workspaceProfile = workspaceProfile;
    }

    /// <inheritdoc />
    public Task<IWorkspaceProfile> GetProfile() => Task.FromResult(_workspaceProfile);
}