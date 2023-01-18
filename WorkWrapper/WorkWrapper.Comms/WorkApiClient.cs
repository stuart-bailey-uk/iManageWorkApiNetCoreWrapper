using Newtonsoft.Json;
using WorkWrapper.Comms.ErrorResponses;
using WorkWrapper.Session;

namespace WorkWrapper.Comms;

public class WorkApiClient : IWorkApiClient
{
    private readonly ISession _session;
    private readonly IHttpClientProxy _httpClientProxy;
    private string? _library = string.Empty;
    private List<JsonConverter>? _converters;

    public WorkApiClient(ISession session, IHttpClientProxy httpClientProxy)
    {
        _session = session;
        _httpClientProxy = httpClientProxy;
    }

    public async Task<T> GetAsync<T>(string uri)
    {
        var message = BuildMessage<T>(uri);

        return await SendAsync<T>(message);
    }

    public async Task<Stream?> GetStreamAsync(string uri)
    {
        var message = BuildMessage<Stream>(uri);

        var response = await SendAsync(message);

        if (!response.IsSuccessStatusCode)
            throw await ErrorResponseFactory.Create(response);

        return await response.Content.ReadAsStreamAsync();
    }

    private HttpRequestMessage BuildMessage<T>(string uri)
    {
        return BuildMessage<T>(HttpMethod.Get, uri);
    }

    private HttpRequestMessage BuildMessage<T>(HttpMethod httpMethod, string uri)
    {
        if (uri.StartsWith("/"))
        {
            uri = uri.TrimStart('/');
        }

        if (!string.IsNullOrEmpty(_library))
        {
            uri = $"libraries/{_library}/{uri}";
        }

        uri = $"/api/v2/customers/{_session.CustomerId}/{uri}";

        var message = new HttpRequestMessage(httpMethod, uri);
        return message;
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
    {
        httpRequestMessage.Headers.Add("Accept", "application/json");
        httpRequestMessage.Headers.Add("X-Auth-Token", _session.Token.AccessToken);

        return await _httpClientProxy.SendAsync(httpRequestMessage);
    }

    public Task<T> SendAsync<T>(HttpMethod httpMethod, string uri, HttpContent? httpContent = null)
    {
        var message = BuildMessage<T>(httpMethod, uri);

        if(httpContent != null)
            message.Content = httpContent;

        return SendAsync<T>(message);
    }

    private async Task<T> SendAsync<T>(HttpRequestMessage httpRequestMessage)
    {
        var uri = httpRequestMessage.RequestUri;

        var response = await SendAsync(httpRequestMessage);

        if (!response.IsSuccessStatusCode)
        {
            throw await ErrorResponseFactory.Create(response);
        }

        var content = await response.Content.ReadAsStringAsync();

        var responseObject = WorkSerializer.DeserializeObject<T>(content);

        if (responseObject == null)
            throw new Exception($"Unable to deserialize response to {typeof(T).Name}");

        return responseObject;
    }

    public IWorkApiClient ForPreferredLibrary()
    {
        _library = _session.PreferredLibrary;

        return this;
    }

    public IWorkApiClient ForLibrary(string? library)
    {
        _library = library;

        return this;
    }

    public IWorkApiClient AttachConverters(JsonConverter jsonConverter)
    {
        _converters ??= new();

        _converters.Add(jsonConverter);

        return this;
    }
}

