namespace WorkWrapper.Comms;

public interface IDataResponse<T>
{
    T? Data { get; set; }
}