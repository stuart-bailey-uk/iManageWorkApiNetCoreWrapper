using WorkWrapper.Core.Models;

namespace WorkWrapper.Documents.Models;

public class StandardDocumentSearchProfile : DocumentSearchProfile, IStandardSearch
{
    public int? TimezoneOffset { get; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }
    public bool? Total { get; set; }
}