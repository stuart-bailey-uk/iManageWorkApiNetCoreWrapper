using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public class StandardCursorDocumentSearchProfile : DocumentSearchProfile, IStandardCursorSearch
{
    public int? TimezoneOffset { get; }
    public string? Cursor { get; set; }
}