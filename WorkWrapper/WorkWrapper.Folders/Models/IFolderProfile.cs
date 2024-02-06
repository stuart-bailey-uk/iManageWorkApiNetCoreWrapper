using WorkWrapper.Core.Models;

namespace WorkWrapper.Folders.Models;

public interface IFolderProfile : IMetadataProfile
{
    public string? Name { get; }

    public string? Owner { get;  }

    public string? WorkspaceId { get; }

    public string? ParentId { get; }
}