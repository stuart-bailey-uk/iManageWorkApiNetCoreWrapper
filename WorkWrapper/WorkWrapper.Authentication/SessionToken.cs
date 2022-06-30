using System.Diagnostics.CodeAnalysis;
using WorkWrapper.Core.Auth;

namespace WorkWrapper.Authentication;

[ExcludeFromCodeCoverage]
internal class SessionToken : ISessionToken
{
    public string AccessToken { get; set; } = string.Empty;
    public int ExpiresIn { get; set; }
    public string TokenType { get; set; } = string.Empty;
    public string Scope { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}