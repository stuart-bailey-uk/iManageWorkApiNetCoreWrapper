using System.Diagnostics.CodeAnalysis;

namespace WorkWrapper.Documents.Models;

[ExcludeFromCodeCoverage]
public class Attachment
{
    public string? AttachmentId { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int Size { get; set; }
}