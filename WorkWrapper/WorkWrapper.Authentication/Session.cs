using System.Diagnostics.CodeAnalysis;
using WorkWrapper.Core.Auth;
using WorkWrapper.Session;

namespace WorkWrapper.Authentication;

[ExcludeFromCodeCoverage]
internal class Session : ISession
{
    private readonly DateTime _sessionCreated;

    public Session(string? baseUrl, ISessionToken sessionToken)
    {
        Token = sessionToken;
        Uri = baseUrl;

        _sessionCreated = DateTime.UtcNow;
    }

    public bool Connected => _sessionCreated.AddSeconds(Token.ExpiresIn) > DateTime.UtcNow;
    public string? CustomerId { get; set; }
    public string? PreferredLibrary { get; internal set; }
    public ISessionToken Token { get; }
    public string? Uri { get; }
    public string? Username { get; internal set; }
}