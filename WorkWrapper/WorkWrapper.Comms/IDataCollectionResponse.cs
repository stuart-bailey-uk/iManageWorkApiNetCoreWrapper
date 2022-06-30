namespace WorkWrapper.Comms;

public interface IDataCollectionResponse<T>
{
    IEnumerable<T> Results { get; }

    int? TotalCount { get; }

    string? Cursor { get; }
}