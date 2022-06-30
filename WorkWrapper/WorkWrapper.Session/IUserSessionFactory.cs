namespace WorkWrapper.Session;

public interface IUserSessionFactory 
{
    ISessionConnector BuildSessionAsync(string userId);
}