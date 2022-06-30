namespace WorkWrapper.Comms;

public interface IStandardPagingCollectionResponse<T> : IDataResponse<T>
{
    int? TotalCount { get; set; }
}