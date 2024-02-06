using WorkWrapper.Core.Models;

namespace WorkWrapper.Workspaces.Models;

public interface IFolderProfile : IMetadataProfile
{
    public string? Name { get; }

    public string? Owner { get;  }

    public string? WorkspaceId { get; }

    public string? ParentId { get; }
}