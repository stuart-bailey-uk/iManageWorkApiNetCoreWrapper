namespace WorkWrapper.Comms;

public interface IHttpClientFactory
{
    IHttpClientProxy Create(string uri);
}