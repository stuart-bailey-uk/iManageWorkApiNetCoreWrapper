namespace WorkWrapper.Comms;

public class HttpClientFactory : IHttpClientFactory
{
    public IHttpClientProxy Create(string uri)
    {
        return new HttpClientProxy(uri);
    }
}