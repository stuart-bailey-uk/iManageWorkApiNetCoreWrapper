namespace WorkWrapper.Core.Auth;

public interface ISessionToken
{
    string AccessToken { get; }

    int ExpiresIn { get; }

    string TokenType { get; }

    string Scope { get; }

    string RefreshToken { get; }
}