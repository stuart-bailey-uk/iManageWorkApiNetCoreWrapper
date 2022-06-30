namespace WorkWrapper.Comms;

public interface IWorkApiClient
{
    Task<T> GetAsync<T>(string uri);

    Task<Stream?> GetStreamAsync(string uri);

    IWorkApiClient ForPreferredLibrary();

    IWorkApiClient ForLibrary(string library);

    Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);

    Task<T> SendAsync<T>(HttpRequestMessage httpRequestMessage);
}