using WorkWrapper.Documents.Models;

namespace WorkWrapper.Workspaces.Models;

public interface IWorkspaceProfile : IWorkProfile
{
    string? Owner { get; }

    string? Description { get; }

    DateTime? DeclaredDate { get; }

    bool? IsDeclared { get; }

    bool? IsExternal { get; }

    bool? IsExternalAsNormal { get; }

    int? RetainDays { get; }
}