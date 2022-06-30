namespace WorkWrapper.Core.Models;

public interface ISearchOptions
{
    public int? TimezoneOffset { get; }
}

public interface IStandardSearch : ISearchOptions
{
    int? Offset { get; set; }

    int? Limit { get; set; }

    bool? Total { get; set; }
}

public interface IStandardCursorSearch : ISearchOptions
{
    string? Cursor { get; set; }

    const string PagingMode = "standard_cursor";
}
