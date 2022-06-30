namespace WorkWrapper.Comms;

public interface ICursorPagingCollectionResponse<T> : IDataResponse<T>
{
    int? Cursor { get; set; }
}