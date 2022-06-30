using System.Net;
using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Core.Auth;
using WorkWrapper.Core.Json;

namespace WorkWrapper.Authentication;

public class VirtualLogon : SessionBuilder
{
    private readonly IHttpClientProxy _httpClientProxy;
    private string? _clientId;
    private string? _clientSecret;
    private string? _password;
    private string? _username;
    private string? _scope;

    public VirtualLogon ForClient(string clientId, string clientSecret)
    {
        _clientId = clientId;

        _clientSecret = clientSecret;

        return this;
    }

    public VirtualLogon ForUser(string username, string password, string scope = "user")
    {
        _username = username;
        _password = password;
        _scope = scope;

        return this;
    }

    public VirtualLogon(string baseUrl, IHttpClientProxy httpClientProxy) : base(baseUrl, new WorkApiClientFactory())
    {
        _httpClientProxy = httpClientProxy;
    }

    protected override async Task<ISessionToken> GetAuthenticatedResponseAsync()
    {
        if (string.IsNullOrEmpty(_clientId) || string.IsNullOrEmpty(_clientSecret))
            throw new Exception($"{nameof(ForClient)} did not get passed a ClientId or ClientSecret");

        if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            throw new Exception($"{nameof(ForUser)} did not get passed a Username or Password");

        var passwordGrantBody = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string?>("username", _username),
            new KeyValuePair<string, string?>("password", _password),
            new KeyValuePair<string, string?>("client_id", _clientId),
            new KeyValuePair<string, string?>("client_secret", _clientSecret),
            new KeyValuePair<string, string?>("scope", _scope),
            new KeyValuePair<string, string?>("grant_type", "password")
        });

        using var response = await _httpClientProxy
            .SendAsync(new HttpRequestMessage(HttpMethod.Post, "auth/oauth2/token") { Content = passwordGrantBody });

        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new WorkApiObjectException(response.StatusCode.ToString(), responseContent);
        }

        SessionToken? sessionObject;
        try
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new WorkJsonContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            sessionObject = JsonConvert.DeserializeObject<SessionToken>(responseContent, settings);
        }
        catch
        {
            sessionObject = null;
        }

        if (sessionObject == null)
            throw new WorkApiObjectException(response.RequestMessage?.RequestUri, responseContent);

        return sessionObject;
    }
}