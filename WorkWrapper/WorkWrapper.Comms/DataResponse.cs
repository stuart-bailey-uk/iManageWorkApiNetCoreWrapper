namespace WorkWrapper.Comms;

public class DataResponse<T> : IDataResponse<T>
{
    public T? Data { get; set; }
}