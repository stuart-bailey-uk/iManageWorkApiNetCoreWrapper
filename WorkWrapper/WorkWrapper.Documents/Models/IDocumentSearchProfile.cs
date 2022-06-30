using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public interface IDocumentSearchProfile : ISearchProfile 
{
    /// <summary>
    /// Filters documents based on the matching text found anywhere in the document's profile or its contents.
    /// </summary>
    string? Anywhere { get; }
    /// <summary>
    /// Filters documents based on the matching text found in a document's content.
    /// </summary>
    string? Body { get; }
    bool? CheckedOut { get; }
    string? Class { get; }
    /// <summary>
    /// Filters documents only from the specified container.
    /// </summary>
    /// <remarks>
    /// The specified container ID can be of a workspace or a folder. For example, ACTIVE_US!222 where "ACTIVE_US" is the library ID and 222 is the container number. Multiple container IDs cannot be specified using a comma-separated list.
    /// </remarks>
    string? ContainerId { get; set; }
    DateTime? CreateDateFrom { get; }
    DateTime? CreateDateTo { get; }
    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    string? CreateDateRelative { get; }
    string? DocumentNumber { get; }
    int? DocumentVersion { get; }
    DateTime? EditDateFrom { get; }
    DateTime? EditDateTo { get; }
    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    string? EditDateRelative { get; }
    bool? EmailOnly { get; }
    bool? ExcludeEmails { get; }
    bool? ExcludeShortcuts { get; }
    bool? HasAttachment { get; }
    string? InUseBy { get; }
    /// <summary>
    /// Specifies whether to search for documents in the specified container and its subtree, or only in the specified container.
    /// </summary>
    bool? IncludeSubtree { get; }
    string? Language { get; }
    string? LastUser { get; }
    bool? Latest { get; }
    string? Name { get; }
    string? Author { get; }
    string? Operator { get; }
    string? Owner { get; }
    /// <summary>
    /// Filters documents to include only the ones that a user accessed in matters in the past 30 days.
    /// </summary>
    bool? Personalized { get; }
    string? Type { get; }
}