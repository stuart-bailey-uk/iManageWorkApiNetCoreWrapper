using Newtonsoft.Json;
using WorkWrapper.Comms;
using WorkWrapper.Core.Auth;
using WorkWrapper.Session;

namespace WorkWrapper.Authentication;

public abstract class SessionBuilder
{
    private readonly IWorkApiClientFactory _workHttpClientFactory;
    private readonly string _baseUrl;

    protected SessionBuilder(string baseUrl, IWorkApiClientFactory workHttpClientFactory)
    {
        _baseUrl = baseUrl;
        _workHttpClientFactory = workHttpClientFactory;
    }

    public async Task<ISession> GetSessionAsync()
    {
        var sessionToken = await GetAuthenticatedResponseAsync();

        var session = new Session(_baseUrl, sessionToken);

        var httpProxy = _workHttpClientFactory.Create(session);

        var request = new HttpRequestMessage(HttpMethod.Get, "api");

        var response = await httpProxy.SendAsync(request);

        var content = await response.Content.ReadAsStringAsync();

        var responseContent = JsonConvert.DeserializeObject<dynamic>(content);

        if (responseContent == null)
            throw new WorkApiException("Response from discovery call invalid");

        session.CustomerId = responseContent.data.user.customer_id.ToString();
        session.PreferredLibrary = responseContent.data.work.preferred_library;

        return session;
    }

    protected abstract Task<ISessionToken> GetAuthenticatedResponseAsync();
}