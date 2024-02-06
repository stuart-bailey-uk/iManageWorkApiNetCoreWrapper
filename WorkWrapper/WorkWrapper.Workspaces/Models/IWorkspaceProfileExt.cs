using WorkWrapper.Core.Models;

namespace WorkWrapper.Workspaces.Models;

public interface IWorkspaceProfileExt : IMetadataProfileExt
{
    string? OwnerDescription { get; }
}