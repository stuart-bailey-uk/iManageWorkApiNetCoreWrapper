using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public interface IDocumentExt : IMetadataProfileExt
{
    string? ClassDescription { get; }
    string? SubClassDescription { get; }
    string? TypeDescription { get; }
    string? InUseByDescription { get; }
    string? LastUserDescription { get; }
    string? AuthorDescription { get; }
    string? OperatorDescription { get; }
}