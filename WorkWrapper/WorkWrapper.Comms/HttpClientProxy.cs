using System.Diagnostics.CodeAnalysis;
using WorkWrapper.Session;

namespace WorkWrapper.Comms;

[ExcludeFromCodeCoverage]
public class HttpClientProxy : IHttpClientProxy
{
    private readonly string? _uri;

    internal HttpClientProxy(string? uri)
    {
        _uri = uri;
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
    {
        using var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_uri ?? throw new InvalidOperationException())
        };

        return await httpClient.SendAsync(httpRequestMessage);
    }
}

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClientFactory()
    {

    }

    public IHttpClientProxy Create(string uri)
    {
        return new HttpClientProxy(uri);
    }
}

public interface IHttpClientFactory
{
    IHttpClientProxy Create(string uri);
}

public interface IWorkApiClientFactory
{
    IWorkApiClient Create(ISession session);
}

public class WorkApiClientFactory : IWorkApiClientFactory
{
    public IWorkApiClient Create(ISession session)
    {
        var proxy = new HttpClientProxy(session.Uri);

        return new WorkApiClient(session, proxy);
    }
}