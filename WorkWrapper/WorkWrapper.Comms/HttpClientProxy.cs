using System.Diagnostics.CodeAnalysis;

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