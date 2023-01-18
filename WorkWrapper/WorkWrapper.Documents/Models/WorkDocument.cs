using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

[ExcludeFromCodeCoverage]
public class WorkDocument : IWorkDocument
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
    public DateTime? Custom21 { get; set; }
    public DateTime? Custom22 { get; set; }
    public DateTime? Custom23 { get; set; }
    public DateTime? Custom24 { get; set; }
    public string? Id { get; set; }
    public string? Database { get; set; }
    public DefaultSecurity? DefaultSecurity { get; set; }
    [Required]
    public string? Type { get; set; }
    public DateTime? EditProfileDate { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Class { get; set; }
    public string? SubClass { get; set; }

    /// <inheritdoc />
    public string? Author { get; set; }

    /// <inheritdoc />
    public string? Operator { get; set; }
    public string? Comment { get; set; }
    public string? ContentType { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? DeclaredDate { get; set; }
    public int? DocumentNumber { get; set; }
    public DateTime? EditDate { get; set; }
    public string? Extension { get; set; }
    public DateTime? FileCreateDate { get; set; }
    public DateTime? FileEditDate { get; set; }
    public bool? IsInUse { get; set; }
    public string? InUseBy { get; set; }
    public bool? IsCheckedOut { get; set; }
    public bool? IsDeclared { get; set; }
    public bool? IsExternal { get; set; }
    public bool? IsExternalAsNormal { get; set; }
    public bool? IsHippa { get; set; }
    public bool? IsRelated { get; set; }
    public bool? IsRestorable { get; set; }
    public string? Iwl { get; set; }
    public string? LastUser { get; set; }
    public int? RetainDays { get; set; }
    public string? WorkspaceId { get; set; }
    public string? WorkspaceName { get; set; }
    [JsonProperty("wstype")]
    public WsType? WsType { get; set; }
    public LockType? LockType { get; set; }

    /// <inheritdoc />
    public long? Size { get; set; }
    public string? Custom1Description { get; set; }
    public string? Custom2Description { get; set; }
    public string? Custom3Description { get; set; }
    public string? Custom4Description { get; set; }
    public string? Custom5Description { get; set; }
    public string? Custom6Description { get; set; }
    public string? Custom7Description { get; set; }
    public string? Custom8Description { get; set; }
    public string? Custom9Description { get; set; }
    public string? Custom10Description { get; set; }
    public string? Custom11Description { get; set; }
    public string? Custom12Description { get; set; }
    public string? Custom29Description { get; set; }
    public string? Custom30Description { get; set; }
    public string? ClassDescription { get; set; }
    public string? SubClassDescription { get; set; }
    public string? TypeDescription { get; set; }
    public string? InUseByDescription { get; set; }
    public string? LastUserDescription { get; set; }
    public string? AuthorDescription { get; set; }
    public string? OperatorDescription { get; set; }
}