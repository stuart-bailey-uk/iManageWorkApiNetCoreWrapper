using System.Text.Json.Serialization;
using Newtonsoft.Json;
using WorkWrapper.Core.Json;
using WorkWrapper.Documents.Actions;

namespace WorkWrapper.Documents.Models;

public abstract class DocumentSearchProfile : IDocumentSearchProfile
{
    public string? Custom1 { get; set; }
    public string? Custom2 { get; set; }
    public string? Custom3 { get; set; }
    public string? Custom4 { get; set; }
    public string? Custom5 { get; set; }
    public string? Custom6 { get; set; }
    public string? Custom7 { get; set; }
    public string? Custom8 { get; set; }
    public string? Custom9 { get; set; }
    public string? Custom10 { get; set; }
    public string? Custom11 { get; set; }
    public string? Custom12 { get; set; }
    public string? Custom13 { get; set; }
    public string? Custom14 { get; set; }
    public string? Custom15 { get; set; }
    public string? Custom16 { get; set; }
    public double? Custom17 { get; set; }
    public double? Custom18 { get; set; }
    public double? Custom19 { get; set; }
    public double? Custom20 { get; set; }
    public bool? Custom25 { get; set; }
    public bool? Custom26 { get; set; }
    public bool? Custom27 { get; set; }
    public bool? Custom28 { get; set; }
    public string? Custom29 { get; set; }
    public string? Custom30 { get; set; }
    public string? Custom31 { get; set; }
    public DateTime? Custom21From { get; set; }
    public DateTime? Custom21To { get; set; }
    public DateTime? Custom22From { get; set; }
    public DateTime? Custom22To { get; set; }
    public DateTime? Custom23From { get; set; }
    public DateTime? Custom23To { get; set; }
    public DateTime? Custom24From { get; set; }
    public DateTime? Custom24To { get; set; }

    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    public string? Custom21Relative { get; set; }

    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    public string? Custom22Relative { get; set; }

    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    public string? Custom23Relative { get; set; }

    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    public string? Custom24Relative { get; set; }

    /// <summary>
    /// Filters documents based on the matching text found anywhere in the document's profile or its contents.
    /// </summary>
    public string? Anywhere { get; set; }

    /// <summary>
    /// Filters documents based on the matching text found in a document's content.
    /// </summary>
    public string? Body { get; set; }
    public bool? CheckedOut { get; set; }
    public string? Class { get; set; }

    /// <summary>
    /// Filters documents only from the specified container.
    /// </summary>
    /// <remarks>
    /// The specified container ID can be of a workspace or a folder. For example, ACTIVE_US!222 where "ACTIVE_US" is the library ID and 222 is the container number. Multiple container IDs cannot be specified using a comma-separated list.
    /// </remarks>
    public string? ContainerId { get; set; }
    public DateTime? CreateDateFrom { get; set; }
    public DateTime? CreateDateTo { get; set; }

    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    public string? CreateDateRelative { get; set; }
    public string? DocumentNumber { get; set; }
    public int? DocumentVersion { get; set; }
    public DateTime? EditDateFrom { get; set; }
    public DateTime? EditDateTo { get; set; }

    /// <summary>
    /// Pattern: ^(([-+]?\d+)([dDwWmMyY])?(:([-+]?(\d+)))([dDwWmMyY]))|(([-+]?\d+)([dDwWmMyY])(:([-+]?(\d+)))([dDwWmMyY])?)|^([-+]?\d+[dDwWmMyY])$
    /// </summary>
    public string? EditDateRelative { get; set; }
    public bool? EmailOnly { get; set; }
    public bool? ExcludeEmails { get; set; }
    public bool? ExcludeShortcuts { get; set; }
    public bool? HasAttachment { get; set; }
    public string? InUseBy { get; set; }

    /// <summary>
    /// Specifies whether to search for documents in the specified container and its subtree, or only in the specified container.
    /// </summary>
    public bool? IncludeSubtree { get; set; }
    public string? Language { get; set; }
    public string? LastUser { get; set; }
    public bool? Latest { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Operator { get; set; }
    public string? Owner { get; set; }

    /// <summary>
    /// Filters documents to include only the ones that a user accessed in matters in the past 30 days.
    /// </summary>
    public bool? Personalized { get; set; }

    public string? Type { get; set; }
}