using System.Diagnostics.CodeAnalysis;
using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

[ExcludeFromCodeCoverage]
public class WorkDocumentExt : WorkDocument
{
    public DocumentOperationPermissions? Operations { get; set; }

    public UserInfo? AuthorInfo { get; set; }

    public UserInfo? LastUserInfo { get; set; }

    public UserInfo? OperatorInfo { get; set; }

    public List<ProfileWarning>? Warnings { get; set; }
}