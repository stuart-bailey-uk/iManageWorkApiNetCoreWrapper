using WorkWrapper.Core.Auth;

namespace WorkWrapper.Session;

public interface ISession
{
    bool Connected { get; }

    string? Username { get; }

    string? PreferredLibrary { get; }

    string? Uri { get; }

    ISessionToken Token { get; }
    string? CustomerId { get; set; }
}