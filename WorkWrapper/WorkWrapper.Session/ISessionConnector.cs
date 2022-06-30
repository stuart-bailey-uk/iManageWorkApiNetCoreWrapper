namespace WorkWrapper.Session;

public interface ISessionConnector : ISession, IDisposable
{
    Task<bool> LogonAsync();

    Task LogoutAsync();
}