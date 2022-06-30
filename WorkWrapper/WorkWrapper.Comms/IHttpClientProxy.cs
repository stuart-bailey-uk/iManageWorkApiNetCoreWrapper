namespace WorkWrapper.Comms;


public interface IHttpClientProxy
{
    public Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
}